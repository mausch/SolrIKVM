using System;
using System.Configuration.Install;
using System.Reflection;
using System.ServiceProcess;

namespace SolrIKVM {
    public static class EntryPoint {
        public static int Main(string[] args) {
            if (Environment.UserInteractive) {
                if (args.Length == 0) {
                    new SolrWindowsService().Start();
                } else if (args[0].StartsWith("/i")) {
                    ManagedInstallerClass.InstallHelper(new[] { Assembly.GetExecutingAssembly().Location });
                } else if (args[0].StartsWith("/u")) {
                    ManagedInstallerClass.InstallHelper(new[] { "/u", Assembly.GetExecutingAssembly().Location });
                }
            } else {
                ServiceBase.Run(new SolrWindowsService());
            }
            return 0;
        }
    }
}