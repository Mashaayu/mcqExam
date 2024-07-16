using EmployeeRH.Context;
using EmployeeRH.Extensions;
using EmployeeRH.Repository;
using EmployeeRH.Repository.IRepository;
using EmployeeRH.SeedData;
using EmployeeRH.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Net;
using Microsoft.AspNetCore.Identity;
using EmployeeRH.Identity;
using System.Text.Json;
using System.Text.Json.Serialization;
using EmployeeRH.AutoMapper;
using AutoMapper;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<EmployeeRHDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyDbcon")));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddDbContext<AppIdentityDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyDbcon")));
        builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
        builder.Services.AddScoped<ITokenService, TokenService>();
        
        builder.Services.AddAutoMapper(typeof(MappingProfile));
       
        builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddIdentityService(builder.Configuration);

        //Config SWagge tp accept JWT token for authorization

        builder.Services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo() { Title = "OpenApi", Version = "v1" });

            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Description = "Please enter a token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            option.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
        {
            new OpenApiSecurityScheme()
            {
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
            });
        });

        DBContextSeed.AddSeedData(); //adding seed  data


        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var LoggerFectory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
                var IdentityDbcontext = services.GetRequiredService<AppIdentityDbContext>();

                await IdentityDbcontext.Database.MigrateAsync();
                await AppIdentitySeed.SeedUserAsync(userManager, roleManager);
            }
            catch (Exception ex)
            {
                var logger = LoggerFectory.CreateLogger<Program>();
                logger.LogError(ex.Message + "Unable to Create Migration");
            }
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}