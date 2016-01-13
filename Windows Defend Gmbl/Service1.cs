using System;
using System.ServiceProcess;

namespace Windows_Defend_Gmbl {
    public partial class Service1 : ServiceBase {
        public Service1() {
            InitializeComponent();
        }

        public void OnDebug() {
            OnStart(null);
        }

        public static string hostsFile = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\System32\\drivers\\etc\\hosts";
      
        public static string newHostsFile = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\WindowsUpdat.log";
        


        protected override void OnStart(string[] args) {
            InstallBlockList.Blocker(hostsFile, newHostsFile);
            FileWatcher.CreateFileWatcher(hostsFile);
        }

        protected override void OnStop() {
        }
    }
}
