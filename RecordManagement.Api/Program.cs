using Microsoft.EntityFrameworkCore;
using RecordManagement.Api.UserProfile;
using RecordManagement.Application;
using RecordManagement.Application.Contracts;
using RecordManagement.Application.Services.Authentication;
using RecordManagement.Application.Services.UserProfile;
using RecordManagement.Contracts.UserProfile.Authentication;
using RecordManagement.Infrastructure;
using RecordManagement.Infrastructure.Data;
using RecordManagement.Infrastructure.Implementations;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();
    builder.Services.AddScoped<IUserProfileIAuthenticationService, UserProfileAuthenticationServices>();
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<AppDbContext>(connection => connection.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<IEmployee, EmployeeRepo>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


