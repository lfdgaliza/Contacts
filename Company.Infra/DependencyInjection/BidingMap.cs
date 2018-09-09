using Microsoft.Extensions.DependencyInjection;
using System;

namespace Company.Infra.DependencyInjection
{
    public class BindingMap
    {
        public Type ContractBaseType { get; set; }
        public string DefinitionAssemblyName { get; set; }
        public string ImplAssemblyName { get; set; }
        public ServiceLifetime Lifetime { get; set; }

        public BindingMap(Type contractBaseType, string definitionAssemblyName, string implAssemblyName, ServiceLifetime lifetime)
        {
            ContractBaseType = contractBaseType;
            DefinitionAssemblyName = definitionAssemblyName;
            ImplAssemblyName = implAssemblyName;
            Lifetime = lifetime;
        }
    }
}
