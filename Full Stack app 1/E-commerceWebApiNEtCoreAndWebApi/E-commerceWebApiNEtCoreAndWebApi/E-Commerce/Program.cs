using E_Commerce.Data;
using E_Commerce.Infrastructure;

//using E_Commerce.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using E_Commerce.Interfaces;
using E_Commerce.Repository;
using E_Commerce.Automapper_Helper;
using E_Commerce.Data.IdentityDbContext;
using E_Commerce.Models.Extensions;
using Microsoft.AspNetCore.Identity;
using E_Commerce.Models.Identity;
using E_Commerce.Interfaces.Token_Interface;
using E_Commerce.Repository.Token_Repo_Implementatio;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddIdentityService(builder.Configuration); //extension method
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreDbcontext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyDbcon")));
builder.Services.AddDbContext<AppIdentityDbcontext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MyDbcon")));

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IProductRepository, ProductRepo>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepo<>));
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

//-------------------
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<StoreDbcontext>();

        await context.Database.MigrateAsync();

        await StoreContextSeed.SeedAsync(context, loggerFactory);


        var UserManager = services.GetRequiredService<UserManager<AppUser>>();
        var IdentityDbcontext = services.GetRequiredService<AppIdentityDbcontext>();

        await IdentityDbcontext.Database.MigrateAsync();

        await AppIdentityDbContectSeed.SeedUserAsync(UserManager);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex.Message + "Unable to Create Migration");
    }

}
//---------------------------
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
//