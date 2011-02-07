using System.IO;

namespace SolrIKVM {
    public static class Setup {
        public static void SetHome(string path) {
            java.lang.System.setProperty("solr.solr.home", path);
            java.lang.System.setProperty("solr.data.dir", Path.Combine(path, "data"));
        }
    }
}