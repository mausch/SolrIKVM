using org.apache.solr.servlet;
using org.mortbay.jetty;
using org.mortbay.jetty.servlet;

namespace SolrIKVM {
    public static class Jetty {
        public static int Main(string[] args) {
            java.lang.System.setProperty("solr.solr.home", @"..\..");
            java.lang.System.setProperty("solr.data.dir", @"..\..\data");
            var server = new Server(8983);
            var servletContext = new Context(server, "/solr");
            var servlet = new SolrServlet();
            servletContext.addServlet(new ServletHolder(servlet), "/*");
            server.start();
            return 0;
        }
    }
}