using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace SolrIKVM {
    [RunInstaller(true)]
    public class SolrWindowsServiceInstaller : Installer {
        public SolrWindowsServiceInstaller() {
            Installers.Add(new ServiceInstaller {
                DisplayName = SolrWindowsService.Name,
                ServiceName = SolrWindowsService.Name,
            });

            Installers.Add(new ServiceProcessInstaller {
                Account = ServiceAccount.NetworkService,
            });
        }
    }
}