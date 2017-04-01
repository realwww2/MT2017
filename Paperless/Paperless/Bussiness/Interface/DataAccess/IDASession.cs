using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paperless.Bussiness
{
    public interface IDASession
    {
        bool Login(string name,string password,out User user);
    }
}
