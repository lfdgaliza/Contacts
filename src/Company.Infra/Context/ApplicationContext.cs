using Microsoft.Extensions.DependencyInjection;
using System;

namespace Company.Infra.Context
{
    public static class ApplicationContext
    {
        private static IServiceProvider _provider;

        public static void SetProvider(IServiceCollection serviceCollection)
        {
            _provider = serviceCollection.BuildServiceProvider();
        }

        public static T Resolve<T>()
        {
            return _provider.GetService<T>();
        }
    }
}
