using System.Configuration;
using System.IO;
using org.apache.solr.servlet;
using org.mortbay.jetty;
using org.mortbay.jetty.servlet;

namespace SolrIKVM {
    public static class Jetty {
        public static int Port {
            get {
                try {
                    return int.Parse(ConfigurationManager.AppSettings["port"]);
                } catch {
                    return 8983;
                }
            }
        }

        public static int Main(string[] args) {
            var home = ConfigurationManager.AppSettings["solr.home"];
            java.lang.System.setProperty("solr.solr.home", home);
            java.lang.System.setProperty("solr.data.dir", Path.Combine(home, "data"));
            var server = new Server(Port);
            var servletContext = new Context(server, "/solr");
            var servlet = new SolrServlet();
            servletContext.addServlet(new ServletHolder(servlet), "/*");
            server.start();
            return 0;
        }
    }
}