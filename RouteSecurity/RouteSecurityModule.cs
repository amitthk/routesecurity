using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace RouteSecurity
{
    public class RouteSecurityModule : IHttpModule
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(RouteSecurityModule));

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(CheckPermissions);
        }

        private void CheckPermissions(object sender, EventArgs e)
        {
            HttpApplication httpApp = (HttpApplication)sender;
            HttpRequest httpReq = httpApp.Context.Request;
            HttpResponse httpResp = httpApp.Context.Response;
            string requestedPage = HttpContext.Current.Request.RawUrl.Replace(HttpContext.Current.Request.ApplicationPath, "");
            string[] reqArray = requestedPage.Split('/');

            string regex2 = System.Configuration.ConfigurationManager.AppSettings.Get("RouteSecurityRegEx");

            if ((!string.IsNullOrEmpty(regex2)) && (Regex.IsMatch(httpReq.Url.AbsoluteUri, regex2)))
            {
                string message = string.Format("This route was blocked: [{0}]", httpReq.Url.AbsoluteUri);
                //log.Error(message);
                //throw new System.Security.SecurityException(message);
                httpResp.StatusCode = 403;
                httpResp.Status = "403 Access Denied. You've been tracked Chicken!";
                httpResp.End();
                return;
            }
        }
    }
}
