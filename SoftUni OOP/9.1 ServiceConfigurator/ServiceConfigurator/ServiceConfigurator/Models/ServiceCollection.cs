using ServiceConfigurator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConfigurator.Models
{
    public class ServiceCollection : IServiceCollection
    {
        Dictionary<Type, Type> mappings;

        public ServiceCollection()
        {
            mappings = new Dictionary<Type, Type>();
        }

        public IServiceCollection AddTransient<TInterface, TImplementation>()
        {
            mappings.Add(typeof(TInterface), typeof(TImplementation));

            return this;
        }

        public Contracts.IServiceProvider BuildServiceProvider()
        {
            throw new NotImplementedException();
        }

        public Type GetMapping(Type interfaceType)
        {
            return mappings[interfaceType];
        }
    }
}
