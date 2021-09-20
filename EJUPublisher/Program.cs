using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using log4net;
using System.Reflection;

namespace EJUPublisher
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .AddSingleton<ILog>(LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType))
                .AddSingleton<IEJUPublisherService, EJUPublisherService>()
                .BuildServiceProvider();

            var EJUPublisher = serviceProvider.GetService<IEJUPublisherService>();

            EJUPublisher.Publish();
        }
    }
}
