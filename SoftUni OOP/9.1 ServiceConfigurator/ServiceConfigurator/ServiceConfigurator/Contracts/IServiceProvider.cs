using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConfigurator.Contracts
{
    public interface IServiceProvider
    {
        object GetService<T>();

    }
}
