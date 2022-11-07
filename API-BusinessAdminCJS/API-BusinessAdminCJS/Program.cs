using API_BusinessAdminCJS;
using API_BusinessAdminCJS.Configurations;
using API_BusinessAdminCJS.Data;
using API_BusinessAdminCJS.Data.Entities;
using API_BusinessAdminCJS.Helpers;
using API_BusinessAdminCJS.IRepository;
using API_BusinessAdminCJS.Repository;
using API_BusinessAdminCJS.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NuGet.Common;
using Serilog;
using Serilog.Events;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Using UseSerilog
Log.Logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(Log.Logger);
Log.Information("Inicio de Aplicacíon");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(o => { o.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = @"JWT Encabezado de autorización usando el esquema Bearer. 
                        Ingrese 'Bearer'[espacio] y luego su token en la entrada de texto a continuación.
                        Ejemplo: 'Bearer 12345abcdef'",
        Name = "Autorización",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "0auth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API BusinessAdmin CJS", Version = "v1" });
});

builder.Services.AddDbContext<DataContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwt(builder.Configuration);
//Extensions
//builder.Services.AddIdentity<Usuario, IdentityRole>(cfg =>
//{
//    //cfg.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
//    //cfg.SignIn.RequireConfirmedEmail = true;
//    //cfg.User.RequireUniqueEmail = true;
//    ////cfg.Password.RequireDigit = true;
//    ////cfg.Password.RequiredUniqueChars = 0;
//    ////cfg.Password.RequireLowercase = true;
//    ////cfg.Password.RequireNonAlphanumeric = true;
//    ////cfg.Password.RequireUppercase = true;
//    //cfg.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//    //cfg.Lockout.MaxFailedAccessAttempts = 3;
//    //cfg.Lockout.AllowedForNewUsers = true;
//})
//    .AddDefaultTokenProviders()
//    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddAutoMapper(typeof(MapperInitializer));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers().AddNewtonsoftJson(op => op.SerializerSettings.ReferenceLoopHandling =
                                                                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(name:"default",pattern:"{controller=Home}/{action=Index}/{id?}");
app.MapControllers();

app.Run();
