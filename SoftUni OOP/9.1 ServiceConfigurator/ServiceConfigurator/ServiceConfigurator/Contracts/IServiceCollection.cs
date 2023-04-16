using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConfigurator.Contracts
{
    public interface IServiceCollection
    {
        IServiceCollection AddTransient<TInterface, TImplementation>();

        Type GetMapping(Type interfaceType);

        IServiceProvider BuildServiceProvider();
    }
}
