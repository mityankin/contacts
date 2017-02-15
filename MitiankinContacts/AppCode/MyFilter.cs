using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MitiankinContacts.AppCode
{
    public class MyFilter : FilterAttribute, IResultFilter
    {

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {

            filterContext.HttpContext.Response.Write("Time Request HTTP: " + filterContext.HttpContext.Timestamp);
            LogMessageToFile(GenerateLogMessage(filterContext));

        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {

            filterContext.HttpContext.Response.Write("Current User: " + filterContext.HttpContext.User.Identity.Name);
        }

        public string GenerateLogMessage(ResultExecutedContext filterContext)
        {
            StringBuilder message = new StringBuilder();
            message.Append(" Browser - ");
            message.Append(filterContext.HttpContext.Request.Browser.Browser);
            message.Append(" UserAgent - ");
            message.Append(filterContext.HttpContext.Request.UserAgent);
            message.Append(" RawUrl - ");
            message.Append(filterContext.HttpContext.Request.RawUrl);
            message.Append(" HttpMethod - ");
            message.Append(filterContext.HttpContext.Request.HttpMethod);
            message.Append(" UserHostAddress - ");
            message.Append(filterContext.HttpContext.Request.UserHostAddress);
            message.Append(" Is user Authenticated -");
            message.Append(filterContext.HttpContext.User.Identity.IsAuthenticated);
            message.Append(" Is user admin -");
            message.Append(filterContext.HttpContext.User.IsInRole("admin"));
            message.Append(" User - ");
            message.Append(filterContext.HttpContext.User.Identity.Name);
            return message.ToString();
        }

        public void LogMessageToFile(string msg)
        {
            var filename = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" + "log.txt";
            using (StreamWriter swr = (File.Exists(filename)) ? File.AppendText(filename) : File.CreateText(filename))
            {
                try
                {
                    string logLine = System.String.Format(
                        "{0:G}: {1}.", System.DateTime.Now, msg);
                    swr.WriteLine(logLine);
                }
                finally
                {
                    swr.Close();
                }
            }
        }

    }
}