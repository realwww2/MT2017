using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paperless.Bussiness
{
    interface IBussinessCreator
    {
        void CreateBussinessServices(IDictionary<Type, Object> services);
        IDASession OpenDASession();
        
    }
}
