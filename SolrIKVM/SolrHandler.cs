using System;
using System.Collections.Generic;
using System.Web;
using javax.servlet;
using org.apache.solr.servlet;

namespace SolrIKVM {
    public class SolrHandler : IHttpHandler, IDisposable {
        private readonly Filter filter;

        public SolrHandler() {
            filter = new SolrDispatchFilter();
            var cfg = new SolrFilterConfig(new Dictionary<string,string> {
                {"path-prefix", null},
                {"solrconfig-filename", null},
            });
            filter.init(cfg);
        }

        public void ProcessRequest(HttpContext context) {
            ProcessRequest(new HttpContextWrapper(context));
        }

        public void ProcessRequest(HttpContextBase context) {
            var request = new ServletRequestAdapter(context);
            var response = new ServletResponseAdapter(context);
            filter.doFilter(request, response, null);
        }

        public bool IsReusable {
            get { return true; }
        }

        public void Dispose() {
            filter.destroy();
        }
    }
}