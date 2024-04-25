using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DeskRoam.Identity;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        return services;
    }
}
