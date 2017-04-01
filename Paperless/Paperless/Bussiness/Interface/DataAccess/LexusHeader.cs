using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paperless.Bussiness
{
    public class LexusInHeader
    {
        public string MessageID { get; set; }
        public string LinkSystemCode { get; set; }
        public string TransmissionDate { get; set; }
    }
    public class LexusOutHeader
    {
        public string MessageID { get; set; }
        public string LinkSystemCode { get; set; }
        public string ReceptionDate { get; set; }
        public string TransmissionDate { get; set; }
    }
}