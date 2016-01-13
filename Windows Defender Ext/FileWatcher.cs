using System.IO;
using System.Threading;

namespace Windows_Defend_Gmbl {
    class FileWatcher {
        private static FileSystemWatcher hostsWatcher;

        public static void CreateFileWatcher(string path) {
            hostsWatcher = new FileSystemWatcher();
            hostsWatcher.Path = Path.GetDirectoryName(path);
            hostsWatcher.Filter = Path.GetFileName(path);

            hostsWatcher.Changed += new FileSystemEventHandler(OnChanged);
            hostsWatcher.Created += new FileSystemEventHandler(OnChanged);
            hostsWatcher.Deleted += new FileSystemEventHandler(OnChanged);
            hostsWatcher.Renamed += new RenamedEventHandler(OnRenamed);
           
            hostsWatcher.EnableRaisingEvents = true;

        }

        private static void OnChanged(object source, FileSystemEventArgs e) {
            try {
                hostsWatcher.EnableRaisingEvents = false;
                Thread.Sleep(2000); //nötig um sicher zu stellen, dass schreibende Zugriff abgeschlossen ist 
                InstallBlockList.Blocker(Service1.hostsFile, Service1.newHostsFile);
            } finally {
                hostsWatcher.EnableRaisingEvents = true;
            }
            
        }

        private static void OnRenamed(object source, RenamedEventArgs e) {
            try {
                hostsWatcher.EnableRaisingEvents = false;
                Thread.Sleep(2000); //nötig um sicher zu stellen, dass schreibende Zugriff abgeschlossen ist 
                InstallBlockList.Blocker(Service1.hostsFile, Service1.newHostsFile);
            } finally {
                hostsWatcher.EnableRaisingEvents = true;
            }
        }
    }
}
