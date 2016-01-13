using System;
using System.IO;

namespace Windows_Defend_Gmbl {
    class InstallBlockList {
        public static void Blocker(string hostsFile, string newHostsFile) {
            String newHostsFromFile;

            try {
                File.Create(hostsFile).Close();

                if (!File.Exists(newHostsFile)) {
                    File.Create(newHostsFile).Close();
                }

                if (!File.Equals(hostsFile, newHostsFile)) {
                    newHostsFromFile = File.ReadAllText(newHostsFile);
                    File.WriteAllText(hostsFile, newHostsFromFile);
                }

            } catch (Exception) {

                throw;
            }
            

           

        }
            
    }
}
