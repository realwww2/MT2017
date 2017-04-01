using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Paperless.Bussiness
{
    public interface ILexusIn
    {
        string url { get; set; }
        LexusInHeader Header { get; set; }
    }
    public abstract class AbstractLexusIn:ILexusIn
    {
        public AbstractLexusIn()
        {
            url = ConfigurationManager.AppSettings[this.GetType().FullName];
        }
        public string url
        {
            get;
            set;
        }

        public LexusInHeader Header
        {
            get;
            set;
        }
    }
}
