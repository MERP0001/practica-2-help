using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using RepairMan.Business;
using RepairMan.Business.Common;
using RepairMan.DataAccess;
using RepairMan.Services.Advertising;
using RepairMan.Services.Common;
using RepairMan.Services.Motoring;
using RepairMan.Services.Repairing;
using RepairMan.API.BasicAuthMiddleware;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretKey"]!)),
        ValidateLifetime = false,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddDbContext<RepairManContext>(x =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    x.UseSqlite("Filename=Database.sqlite");
    x.LogTo(s => Console.WriteLine(s));
    x.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IWorkshopCategoryService, WorkshopCategoryService>();
builder.Services.AddScoped<IWorkshopService, WorkshopService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IAdvertisementService, AdvertisementService>();
builder.Services.AddScoped<IDataFileService, DataFileService>();
builder.Services.AddScoped<IUserControlLogic, UserControlLogic>();
builder.Services.AddScoped<IDiagnosticLogic, DiagnosticLogic>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API TuMecanicoRD", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Place your token right before bearer and a space.",
        Name = "Authorization",
        Scheme = "Bearer",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });

    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authentication with fixed username and password"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "basic"
                }
            },
            new List<string>()
        }
    });
});

var contentDirectory = builder.Configuration["ContentDirectory"];
if(!Directory.Exists(contentDirectory))
{
    Directory.CreateDirectory(contentDirectory);
}


var app = builder.Build();

app.UseMiddleware<BasicAuthMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
