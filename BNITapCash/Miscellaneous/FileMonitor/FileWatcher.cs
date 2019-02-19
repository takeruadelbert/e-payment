using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BNITapCash.Helper;

namespace BNITapCash.Miscellaneous.FileMonitor
{
    class FileWatcher
    {
        private FileSystemWatcher watcher;
        public static List<string> newFile;
        private TKHelper tk = new TKHelper(); 

        public FileWatcher()
        {
            string settlementDir = tk.GetDirectoryName() + "\\settlement";
            watcher = new FileSystemWatcher(@settlementDir);
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            watcher.Created += watcher_Created;
            watcher.Renamed += wathcer_Renamed;
            watcher.Deleted += watcher_Deleted;
            newFile = new List<string>();
        }

        static void wathcer_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("File : {0} renamed to {1} at time : {2}", e.OldName, e.Name, DateTime.Now.ToLocalTime());
        }

        static void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File : {0} deleted at time : {1}", e.Name, DateTime.Now.ToLocalTime());
        }

        static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File : {0} created at time : {1}", e.Name, DateTime.Now.ToLocalTime());
            newFile.Add(e.Name);
        }
    }
}
