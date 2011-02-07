using System;
using System.Configuration;
using org.apache.solr.client.solrj.embedded;

namespace SolrIKVM {
    public static class Jetty {
        public static int Port {
            get {
                var p = ConfigurationManager.AppSettings["port"];
                if (string.IsNullOrEmpty(p))
                    return 8983;
                try {
                    return int.Parse(p);
                } catch (Exception e) {
                    throw new Exception(string.Format("Invalid port '{0}'", p), e);
                }
            }
        }

        public static int Main(string[] args) {
            var home = ConfigurationManager.AppSettings["solr.home"];
            Setup.SetHome(home);
            var jetty = new JettySolrRunner("/solr", Port);
            jetty.start();
            return 0;
        }
    }
}