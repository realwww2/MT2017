using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Paperless.Bussiness
{
    public class InvokeDirector
    {
        public ILexusOut Invoke(ILexusIn lexusIn,Type outType)
        {
            //Debug.Assert(...);
            string xml = In2Xml(lexusIn);
            string returnXml = PostXmlToUrl(xml, lexusIn.url);
            return Xml2Out(returnXml, outType);
        }
        private string In2Xml(ILexusIn lexusIn)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xs = new XmlSerializer(lexusIn.GetType());
            xs.Serialize(Stream, lexusIn);
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string xml = sr.ReadToEnd();
            sr.Dispose();
            Stream.Dispose();
            return xml;
        }
        private string PostXmlToUrl(string xml,string url)
        {
            string returnXml = "";
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                returnXml = wc.UploadString(url, "POST", xml);
            }
            return returnXml;
        }
        private ILexusOut Xml2Out(string xml,Type outType)
        {
            ILexusOut lexusOut;
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xs = new XmlSerializer(outType);
                lexusOut = xs.Deserialize(sr) as ILexusOut;
            }
            return lexusOut;
        }
    }
}