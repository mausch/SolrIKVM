using System;
using System.Web;
using SolrIKVM;

namespace SolrAspNet {
    public class Global : HttpApplication {
        protected void Application_Start(object sender, EventArgs e) {
            SolrHandler.SetHome(@"c:\prg\mausch\SolrIKVM\SolrIKVM");
        }

        protected void Session_Start(object sender, EventArgs e) {}

        protected void Application_BeginRequest(object sender, EventArgs e) {}

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {}

        protected void Application_Error(object sender, EventArgs e) {}

        protected void Session_End(object sender, EventArgs e) {}

        protected void Application_End(object sender, EventArgs e) {}
    }
}