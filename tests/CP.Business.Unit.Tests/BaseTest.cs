using CP.Abstractions.Models;
using CP.Business.Unit.Tests.Common;
using CP.Business.Unit.Tests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;

[assembly: Isolated]
namespace CP.Business.Unit.Tests
{
    public class BaseTest
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        public static ServiceProvider ServiceProvider;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        static BaseTest()
        {
            ServiceProvider = SetupDependencies();
        }

        public BaseTest()
        {
        }

        [SetUp]
        public void Init()
        {
            //some tests need affect static mock data need to be reset before each test
            ServiceProvider = SetupDependencies();
        }

        private static ServiceProvider SetupDependencies()
        {
            var appSettings = new AppSettings
            {
                Settings = new AppSettings.SettingsObject
                {
                    InTestMode = true,
                    UseMockForDatabase = true
                }
            };

            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection = CP.Bootstrapper.BootstrapperCommon.AddDependenciesToServiceCollection(serviceCollection, appSettings);

            //profile tests specific?
            serviceCollection.AddScoped(typeof(ILogger<>), typeof(MockLogger<>));

            return serviceCollection.BuildServiceProvider();
        }

        public string GenerateId(string prefix)
        {
            string stamp = string.Format("{0}{1:yyMMddHHmmssfff}", prefix, DateTime.Now);
            return stamp;
        }

        public string ReadResource(string resourceName)
        {
            // Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Get all resource names in a case-insensitive manner
            var resourcePath = assembly.GetManifestResourceNames()
                                       .FirstOrDefault(name => string.Equals(name, $"{assembly.GetName().Name}.{resourceName}", StringComparison.OrdinalIgnoreCase));

            if (resourcePath == null)
            {
                throw new FileNotFoundException($"Resource {resourceName} not found.");
            }

            // Use the assembly to access the resource stream
            using Stream? stream = assembly.GetManifestResourceStream(resourcePath);
            if (stream == null)
            {
                throw new FileNotFoundException($"Resource {resourceName} not found.");
            }

            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
