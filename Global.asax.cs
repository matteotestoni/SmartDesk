namespace Rswstudio
{
    using System;
    using System.Text;
    using System.Diagnostics;
    using System.Web.Routing;

    public partial class App : System.Web.HttpApplication
    {
        public Guid AppId = Guid.NewGuid();
        

        protected void Application_Start()
        {
            
            log4net.Config.XmlConfigurator.Configure();
        }

        public String GetAppDescription(String eventName)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("-------------------------------------------{0}", Environment.NewLine);
            builder.AppendFormat("Event: {0}{1}", eventName, Environment.NewLine);
            builder.AppendFormat("Guid: {0}{1}", AppId, Environment.NewLine);
            builder.AppendFormat("Thread Id: {0}{1}", System.Threading.Thread.CurrentThread.ManagedThreadId, Environment.NewLine);
            builder.AppendFormat("Appdomain: {0}{1}", AppDomain.CurrentDomain.FriendlyName, Environment.NewLine);
            builder.Append((System.Threading.Thread.CurrentThread.IsThreadPoolThread ? "Pool Thread" : "No Thread") + Environment.NewLine);
            return builder.ToString();
        }

        void Application_End(object sender, EventArgs e)
        {
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError().GetBaseException();
            //log.Error(ex);  // LOG Error 

            // Code that runs when an unhandled error occurs
            Trace.WriteLine(GetAppDescription("Application_Error"));

            // GESTIONE ERRORE
            string strSubject = "RswStudio App Gestione";
            string strBody = "<font color=\"#FF0000\"><strong>Url:</strong></font> " + Request.Url.ToString();
            strBody += "<br />";
            strBody += "<font color=\"#FF0000\"><strong>PathAndQuery:</strong></font> " + Request.Url.PathAndQuery.ToString();
            strBody += "<br />";
            strBody += "<font color=\"#FF0000\"><strong>QueryString:</strong></font> " + Request.QueryString.ToString();
            strBody += "<br />";
            strBody += "<font color=\"#FF0000\"><strong>RawUrl:</strong></font> " + Request.RawUrl.ToString();
            strBody += "<br />";
            strBody += "<font color=\"#FF0000\"><strong>Form:</strong></font> " + Request.Form.ToString();
            strBody += "<br />";
            if (ex != null)
            {
                strBody += "<font color=\"#FF0000\"><strong>GetLastError Message:</strong></font> " + ex.Message.ToString();
                strBody += "<br />";
                strBody += "<font color=\"#FF0000\"><strong>GetLastError Source:</strong></font> " + ex.Source.ToString();
                strBody += "<br />";
                strBody += "<font color=\"#FF0000\"><strong>GetLastError StackTrace:</strong></font> " + ex.StackTrace.ToString();
                Server.ClearError();
            }

            Smartdesk.Mail.Send(strSubject, strBody, Smartdesk.Config.Mail.Parametres.ErrTo, Smartdesk.Config.Mail.Parametres.ErrCc);
            //Response.Redirect(Smartdesk.Current.LoginPageRoot);
            Response.Write(strBody);

        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Url.AbsoluteUri.Contains(".well-known") == false)
            {
                if (!Request.IsSecureConnection)
                {
                    string path = string.Format("https{0}", Request.Url.AbsoluteUri.Substring(4));
                    Response.Redirect(path);
                }
            }
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
        }

    }

}
