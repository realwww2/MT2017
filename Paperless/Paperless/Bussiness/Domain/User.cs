using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paperless.Bussiness
{
    /// <summary>
    /// User Type
    /// </summary>
    public enum UserType
    {
        New,
        NoCourseFee,
        CourseFee
    }
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        public string Name { get; set; }
        public UserType userType { get; set; }

        public static UserType Str2UserType(string str)
        {
            return (UserType)Enum.Parse(typeof(UserType), str) ;
        }
    }
}