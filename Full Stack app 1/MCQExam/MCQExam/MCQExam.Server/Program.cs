
using MCQExam.Server.Context;
using MCQExam.Server.Extension;
using MCQExam.Server.Identity;
using MCQExam.Server.Models.SeedData;
using MCQExam.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using AutoMapper;
using MCQExam.Server.AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MCQExam.Server.Repository;


namespace MCQExam.Server
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<AppIdentityDbContext>
                (opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection")));
            builder.Services.AddDbContext<MCQExamDbContext>
                (opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("MyDbCon")));
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddAutoMapper(typeof(MappingProfiles));

            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));

            //Authentication JWT
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

            ///adding seed data
            using (var scope = app.Services.CreateScope())
            {
                var Services = scope.ServiceProvider;
                var loggerFactory = Services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var UserManager = Services.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = Services.GetRequiredService<RoleManager<AppRole>>();
                    var IdentityContext = Services.GetRequiredService<AppIdentityDbContext>();
                    var dbContect = Services.GetRequiredService<MCQExamDbContext>();

                    await IdentityContext.Database.MigrateAsync();
                    await AppIdentityDbContextSeed.SeedUser(UserManager, roleManager);
                   // await MCQExamDbContextSeed.AddSeedData(dbContect,UserManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex.Message);
                }
            }


            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }

}




