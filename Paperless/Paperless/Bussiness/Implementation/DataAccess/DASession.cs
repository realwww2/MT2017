using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paperless.Bussiness
{
    public class DASession : IDASession
    {
        private InvokeDirector _director = new InvokeDirector();
        public bool Login(string name, string password, out User user)
        {
            user = null;
            InLogin i = new InLogin(name, password);
            OutLogin o = _director.Invoke(i, typeof(OutLogin)) as OutLogin;
            switch (o.Result)
            {
                case "60000":
                    user = new User();
                    user.Name = o.Name;
                    user.userType = User.Str2UserType(o.UserType);
                    return true;
                case "60001":
                    throw new DataAccessException(o.Result);
                case "60002":
                    return false;
                case "69999":
                    break;
                default:
                    throw new DataAccessException(o.Result);
            }
            return true;

        }


    }
}