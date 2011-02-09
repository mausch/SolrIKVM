using System;
using System.Configuration;
using org.apache.solr.client.solrj.embedded;

namespace SolrIKVM {
    public static class Jetty {
        public static int Main(string[] args) {
            var home = ConfigurationManager.AppSettings["solr.home"];
            Setup.SetHome(home);
            var jetty = new JettySolrRunner("/solr", Setup.Port());
            jetty.start();
            return 0;
        }
    }
}