using System;
using System.Configuration;
using System.IO;

namespace SolrIKVM {
    public static class Setup {
        public static void SetHome(string path) {
            java.lang.System.setProperty("solr.solr.home", path);
            java.lang.System.setProperty("solr.data.dir", Path.Combine(path, "data"));
        }

        public static Func<int> Port = GetPortFromConfig;

        public static int GetPortFromConfig() {
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
}