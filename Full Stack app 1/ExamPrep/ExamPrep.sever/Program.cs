using ExamPrep.sever.Context;
using ExamPrep.sever.Service;
using Microsoft.EntityFrameworkCore;
using ExamPrep.sever.Exetention;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using ExamPrep.sever.Identity;
using ExamPrep.sever.SeedData;
using ExamPrep.sever.hubs;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.



        builder.Services.AddDbContext<UniversityDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabaseConnection")));
        builder.Services.AddDbContext<AppIdentityDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyDatabaseConnection")));
        builder.Services.AddScoped<ITokenService, TokenService>();

        builder.Services.AddIndetityService(builder.Configuration);
        builder.Services.AddSignalR();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();//builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {

        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
                    });
        });


        var app = builder.Build();
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggingFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var IdentityDbcontext = services.GetRequiredService<AppIdentityDbContext>();
                var Dbcontext = services.GetRequiredService<UniversityDbContext>();
                var roleManager = services.GetRequiredService<RoleManager<AppRole>>();  

                await AppIdentityDbContextSeed.SeedUserAsync(IdentityDbcontext, userManager ,roleManager);
                await DbContextSeed.AddSeedDataAsync(Dbcontext);

            }

            catch (Exception ex)
            {
                var logger = loggingFactory.CreateLogger<Program>();
                logger.LogError(ex.Message);
            }


        }



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(x => x.AllowAnyOrigin()
                        .AllowAnyMethod()
                    .AllowAnyHeader());

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapHub<UserHub>("hubs/UserCount");

        app.Run();
    }
}