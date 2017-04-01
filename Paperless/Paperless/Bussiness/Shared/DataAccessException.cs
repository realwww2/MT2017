using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paperless.Bussiness
{
    //We only have DataAccessException but no ServiceException because all logic error of Service layer will be handled by self layer.
    //The DataAccessException were raised by DASession but it will be handled by other top layer, like controller or service
    //

    public class DataAccessException:Exception 
    {
        public DataAccessException (string errorCode)
        {
            ErrorCode = errorCode;
        }
        public string ErrorCode { get; set; }
    }
}