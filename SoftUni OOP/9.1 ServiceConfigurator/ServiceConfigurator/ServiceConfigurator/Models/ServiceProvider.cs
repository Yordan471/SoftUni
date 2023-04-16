using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConfigurator.Models
{
    public class ServiceProvider : Contracts.IServiceProvider
    {
        public T GetService<T>()
        {
            throw new NotImplementedException();
        }
    }
}
