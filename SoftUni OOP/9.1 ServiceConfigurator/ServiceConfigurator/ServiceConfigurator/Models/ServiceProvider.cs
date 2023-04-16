using ServiceConfigurator.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConfigurator.Models
{
    public class ServiceProvider : Contracts.IServiceProvider
    {
        private IServiceCollection serviceCollection;

        public ServiceProvider (IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection;
        }

        public object GetService<T>()
        {
            return GetService(typeof(T));
        }

        public object GetService(Type type)
        {
            Type implementationType = serviceCollection.GetMapping(type);

            ConstructorInfo constructor = implementationType.GetConstructors()[0];
            ParameterInfo[] parameters = constructor.GetParameters();
            object[] parameterObjects = new object[parameters.Length];

            foreach (ParameterInfo parameter in parameters)
            {
                GetService(parameter.ParameterType);
            }

            return Activator.CreateInstance(type, parameterObjects);
        }
            
    }
}
