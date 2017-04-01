using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Configuration;

namespace Paperless.Bussiness
{
    public class BussinessFactory
    {
        public static BussinessFactory Instance = new BussinessFactory();

        private IDictionary<Type, Object> _Services;
        private IBussinessCreator _creator;
        private BussinessFactory()
        {
            _Services = new Dictionary<Type,Object>();
            string creatorTypeStr = ConfigurationManager.AppSettings["BussinessCreator"];
            _creator = System.Activator.CreateInstance(Type.GetType(creatorTypeStr)) as IBussinessCreator;
            _creator.CreateBussinessServices (_Services);
            
        }
        public IDASession OpenDASession()
        {
            return _creator.OpenDASession();
        }
        public IUserService userService
        {
            get { return (IUserService)_Services[typeof(IUserService)]; }
        }
    }
}