using Scalar.AspNetCore;
using UniformSystem.Data;
using UniformSystem.Exceptions;
using UniformSystem.Features.Users.Repositories;
using UniformSystem.Features.Employees.Repositories;
using UniformSystem.Features.Uniforms.Repositories;
using UniformSystem.Security;
using UniformSystem.Features.Users.Services;
using UniformSystem.Features.Employees.Services;
using UniformSystem.Features.Uniforms.Services;

var builder = WebApplication.CreateBuilder(args);
var allowFrontend = "_allowFrontend";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowFrontend,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        });
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddDbContext<AppDatabaseContext>();
builder.Services.AddSingleton<PasswordHasher>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IUniformRepository, UniformRepository>();
builder.Services.AddScoped<IUniformService, UniformService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/docs");
}

app.UseExceptionHandler();
app.UseCors(allowFrontend);
app.UseHttpsRedirection();
app.MapControllers();
app.Run();