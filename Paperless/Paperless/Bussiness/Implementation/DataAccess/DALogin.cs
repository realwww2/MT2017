using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paperless.Bussiness
{
    public class InLogin:AbstractLexusIn
    {
        public InLogin(string name,string password)
        {

            this.Header = new LexusInHeader();
            Header.MessageID = "WEBAPI0001";
            Header.LinkSystemCode = "30";
            Header.TransmissionDate = DateTime.Now.ToString("yyyy/mm/dd hh:mm:ss");
        }
        public string Name { get; set; }
        public string Password { get; set; }
       
    }
    public class OutLogin:AbstractLexusOut
    {
        public OutLogin()
        {
            this.Header = new LexusOutHeader();
            Header.MessageID = "WEBAPI0001";
            Header.LinkSystemCode = "30";
            Header.ReceptionDate = DateTime.Now.ToString("yyyy/mm/dd hh:mm:ss");
            Header.TransmissionDate = DateTime.Now.ToString("yyyy/mm/dd hh:mm:ss");
        }
        
        public string Result { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
    }
}