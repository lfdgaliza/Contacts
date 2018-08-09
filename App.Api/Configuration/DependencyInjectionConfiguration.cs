using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace App.Api.Configuration
{
    public class BindingMap
    {
        public Type ContractBaseType { get; set; }
        public string[] ImplAssemblyNames { get; set; }
        public ServiceLifetime Lifetime { get; set; }

        public BindingMap(Type contractBaseType, string[] implAssemblyNames, ServiceLifetime lifetime)
        {
            ContractBaseType = contractBaseType;
            ImplAssemblyNames = implAssemblyNames;
            Lifetime = lifetime;
        }
    }

    public static class ServicesExtensions
    {
        public static void AddDomain(this IServiceCollection services, List<BindingMap> bindingMaps)
        {
            bindingMaps.ForEach(bindingMap =>
            {
                var assemblies = new List<Assembly>();
                foreach (var assemblyName in bindingMap.ImplAssemblyNames)
                    assemblies.Add(Assembly.Load(assemblyName));

                var serviceInterfaces = GetInterfaces(bindingMap.ContractBaseType);
                var serviceImplementations = GetImplementations(serviceInterfaces, assemblies);
                BindServices(services, serviceInterfaces, serviceImplementations, bindingMap.Lifetime);
            });
        }

        private static void BindServices(IServiceCollection services, List<Type> interfaces, List<Type> implementations, ServiceLifetime lifetime)
        {
            interfaces.ForEach(serviceInterface =>
            {
                var mustBeOneImplementation = implementations
                .Where(impl => serviceInterface.IsAssignableFrom(impl))
                .ToList();

                if (mustBeOneImplementation.Count < 1)
                    throw new NotImplementedException($"Interface {serviceInterface.FullName} não implementada.");
                if (mustBeOneImplementation.Count > 1)
                {
                    var implementationsName = String.Join(", ", mustBeOneImplementation.Select(i => i.FullName));
                    throw new NotSupportedException($"Existe mais de uma implementação para a mesma interface: {implementationsName}");
                }

                var implementation = mustBeOneImplementation.Single();

                services.Add(new ServiceDescriptor(serviceInterface, implementation, lifetime));
            });
        }

        private static List<Type> GetInterfaces(Type baseContractType)
        {
            return baseContractType.Assembly.GetTypes()
                        .Where(type => baseContractType.IsAssignableFrom(type)
                                        && type.IsInterface
                                        && type != baseContractType)
                        .ToList();
        }

        private static List<Type> GetImplementations(List<Type> interfaces, List<Assembly> assemblies)
        {
            var implementations = new List<Type>();

            assemblies.ForEach(assembly =>
            {
                interfaces.ForEach(itfc =>
                {
                    implementations.AddRange(assembly.GetTypes().Where(impl => itfc.IsAssignableFrom(impl) && impl.IsClass));
                });
            });

            return implementations;
        }
    }
}
