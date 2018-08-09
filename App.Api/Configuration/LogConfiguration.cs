using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;

namespace App.Api.Configuration
{
    public static class LogConfiguration
    {
        public static void Configure()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}
