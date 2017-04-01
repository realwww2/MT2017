using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Paperless.Bussiness
{
    public class BussinessCreator:IBussinessCreator 
    {
        public void CreateBussinessServices(IDictionary<Type, object> services)
        {
            //We must change here after defined DataAccess layer
            services.Add(typeof(IUserService), new UserService());
        }
        public IDASession OpenDASession()
        {
            return new DASession();
        }
    }
}