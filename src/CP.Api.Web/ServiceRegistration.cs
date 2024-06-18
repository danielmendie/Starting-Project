using CP.Abstractions.Models;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension class that adds support for registering dependencies to IOC container
    /// </summary>
    public static class ServiceRegistrationExtensions
    {
        /// <summary>
        /// Extension method that adds support for registering dependencies to IOC container
        /// </summary>
        public static IServiceCollection AddDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            CP.Bootstrapper.BootstrapperCommon.AddDependenciesToServiceCollection(services, appSettings);

            //add http context
            services.AddHttpContextAccessor();

            return services;
        }

    }
}
