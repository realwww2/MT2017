using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Text;
using System.Web.Mvc;
namespace Paperless.Log
{
    public class Logger
    {
        private string _errorPath = string.Empty;
        private string _debugPath = string.Empty;
        public Logger ()
        {
            _errorPath = GetLogPath("LogError");
            _debugPath = GetLogPath("LogDebug");
        }      
        public void LogError(string str)
        {
            str = string.Format("\nLogError Start:{0}\n{1}", DateTime.Now.ToString("Log at dd-MM-yyyy hh mm ss"), str);
            File.AppendAllText(_errorPath, str);
        }
        public void LogError(Exception e)
        {
            StringBuilder sb = new StringBuilder();
            CreateExceptionString(sb, e.InnerException, "  ");
            LogError(sb.ToString());
        }
        public void LogError(ExceptionContext ec)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\nError for ExceptionContext at Controller {1}", ec.Controller);
            CreateExceptionString(sb, ec.Exception.InnerException, "  ");
            LogError(sb.ToString());
        }
        public void LogDebug(string str)
        {
            File.AppendAllText(_debugPath, str);
        }
        private string GetLogPath(string key)
        {
            string path = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[key]);
            path = path.Replace("[Date]", DateTime.Now.Date.ToString("dd-MM-yyyy"));
            path = path.Replace("[Time]", DateTime.Now.ToString("dd-MM-yyyy hh mm ss"));
            return path;
        }

        private void CreateExceptionString(StringBuilder sb, Exception e, string indent)
        {
            sb.AppendFormat("{0}Inner ", indent);

            sb.AppendFormat("Exception Found:\n{0}Type: {1}", indent, e.GetType().FullName);
            sb.AppendFormat("\n{0}Message: {1}", indent, e.Message);
            sb.AppendFormat("\n{0}Source: {1}", indent, e.Source);
            sb.AppendFormat("\n{0}Stacktrace: {1}", indent, e.StackTrace);

            if (e.InnerException != null)
            {
                sb.Append("\n");
                CreateExceptionString(sb, e.InnerException, indent + "  ");
            }
        }
    }
}