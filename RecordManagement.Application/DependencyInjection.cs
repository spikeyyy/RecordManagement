using Microsoft.Extensions.DependencyInjection;
using RecordManagement.Application.Services.Authentication;

namespace RecordManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationServices, AuthenticationServices>();
        return services;
    }
}