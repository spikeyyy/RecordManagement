using Microsoft.Extensions.DependencyInjection;
using RecordManagement.Application.Common.Interfaces.Authentication;
using RecordManagement.Application.Common.Interfaces.Persistence;
using RecordManagement.Application.Services;
using RecordManagement.Infrastructure.Authentication;
using RecordManagement.Infrastructure.Persistence;
using RecordManagement.Infrastructure.Services;

namespace RecordManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvide>();

        services.AddScoped<IUserProfileRepository, UserProfileRepository>();
        return services;
    }
}