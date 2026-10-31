using System.Text;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using UniformSystem.Data;
using UniformSystem.Entities;
using UniformSystem.Exceptions;
using UniformSystem.Features.Auth.Services;
using UniformSystem.Features.Users.Repositories;
using UniformSystem.Features.Employees.Repositories;
using UniformSystem.Features.Uniforms.Repositories;
using UniformSystem.Security;
using UniformSystem.Features.Users.Services;
using UniformSystem.Features.Employees.Services;
using UniformSystem.Features.Inventory.Repositories;
using UniformSystem.Features.Inventory.Services;
using UniformSystem.Features.Jwt.Services;
using UniformSystem.Features.Permissions.Repositories;
using UniformSystem.Features.Permissions;
using UniformSystem.Features.Tokens.Repositories;
using UniformSystem.Features.Tokens.Services;
using UniformSystem.Features.Uniforms.Services;
using UniformSystem.Features.UniformsDelivered.Repositories;
using UniformSystem.Features.UniformsDelivered.Services;
using UniformSystem.Maps;
using UniformSystem.Security.Permissions;

var builder = WebApplication.CreateBuilder(args);
var allowFrontend = "_allowFrontend";

MappingConfig.RegisterMappings();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("Missing JWT Key"))),
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowFrontend,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("inventory.read", policy => policy.Requirements.Add(new PermissionRequirement(PermissionCatalog.InventoryRead)));
    options.AddPolicy("delivery.read", policy => policy.Requirements.Add(new PermissionRequirement(PermissionCatalog.DeliveryRead)));
    
    options.AddPolicy("inventory.update", policy => policy.Requirements.Add(new PermissionRequirement(PermissionCatalog.InventoryUpdate)));
    options.AddPolicy("delivery.update", policy => policy.Requirements.Add(new PermissionRequirement(PermissionCatalog.DeliveryUpdate)));
    
    options.AddPolicy("delivery.create", policy => policy.Requirements.Add(new PermissionRequirement(PermissionCatalog.DeliveryCreate)));
    
    options.AddPolicy("users.manage", policy => policy.Requirements.Add(new PermissionRequirement(PermissionCatalog.UsersManage)));
    options.AddPolicy("uniform.manage", policy => policy.Requirements.Add(new PermissionRequirement(PermissionCatalog.UniformManage)));
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDbContext<AppDatabaseContext>();
builder.Services.AddSingleton<PasswordHasher>();
builder.Services.AddSingleton<JwtService>();

builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);

builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IUniformRepository, UniformRepository>();
builder.Services.AddScoped<IUniformDeliveredRepository, UniformDeliveredRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryLogsRepository, InventoryLogsRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IUniformService, UniformService>();
builder.Services.AddScoped<IUniformDeliveredService, UniformDeliveredService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IInventoryLogsService, InventoryLogsService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/docs");
}

app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(allowFrontend);
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
