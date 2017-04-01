using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Paperless.Bussiness
{
    public class UserService : IUserService
    {
        public bool Login(string name, string password, out User user)
        {
            //Undefined DataAccess Interface so fake one
            //user = new User();
            //user.Name = name;
            //user.userType = UserType.New;
            IDASession session = BussinessFactory.Instance.OpenDASession();
            try
            {
                return session.Login(name, password, out user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
