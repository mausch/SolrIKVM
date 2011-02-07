using System;
using System.IO;
using System.Web;
using javax.servlet;
using javax.servlet.http;
using org.apache.solr.servlet;

namespace SolrIKVM {
    public class SolrHandler : IHttpHandler, IDisposable {
        public static void SetHome(string path) {
            java.lang.System.setProperty("solr.solr.home", path);
            java.lang.System.setProperty("solr.data.dir", Path.Combine(path, "data"));
        }

        private readonly HttpServlet servlet;

        public SolrHandler() {
            servlet = new SolrServlet();
            servlet.init();
        }

        public void ProcessRequest(HttpContext context) {
            ProcessRequest(new HttpContextWrapper(context));
        }

        public void ProcessRequest(HttpContextBase context) {
            var request = new ServletRequestAdapter(context);
            var response = new ServletResponseAdapter(context);
            servlet.service(request, response);
        }

        public bool IsReusable {
            get { return true; }
        }

        public void Dispose() {
            servlet.destroy();
        }
    }
}