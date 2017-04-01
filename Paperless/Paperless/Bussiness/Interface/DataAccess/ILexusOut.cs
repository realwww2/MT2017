using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Paperless.Bussiness
{
    public interface ILexusOut
    {
        string url { get; set; }
        LexusOutHeader Header { get; set; }
    }

    public abstract class AbstractLexusOut : ILexusOut
    {
        public AbstractLexusOut()
        {
            url = ConfigurationManager.AppSettings[this.GetType().FullName];
        }
        public string url
        {
            get;
            set;
        }

        public LexusOutHeader Header
        {
            get;
            set;
        }

    }
}
