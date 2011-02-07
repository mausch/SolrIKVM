using System.Configuration;
using System.IO;
using org.apache.solr.client.solrj.embedded;

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
            Setup.SetHome(home);
            var jetty = new JettySolrRunner("/solr", Port);
            jetty.start();
            return 0;
        }
    }
}