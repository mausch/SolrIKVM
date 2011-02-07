using System;
using System.Configuration;
using System.IO;
using System.Web;
using SolrIKVM;

namespace SolrAspNet {
    public class Global : HttpApplication {
        protected void Application_Start(object sender, EventArgs e) {
            var root = Server.MapPath("/");
            var solrHome = Path.Combine(root, ConfigurationManager.AppSettings["solr.home"]);
            SolrHandler.SetHome(solrHome);
        }

        protected void Session_Start(object sender, EventArgs e) {}

        protected void Application_BeginRequest(object sender, EventArgs e) {}

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {}

        protected void Application_Error(object sender, EventArgs e) {}

        protected void Session_End(object sender, EventArgs e) {}

        protected void Application_End(object sender, EventArgs e) {}
    }
}