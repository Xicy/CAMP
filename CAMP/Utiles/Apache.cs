using System;
using System.IO;

namespace CAMP.Utiles
{
    public class Apache
    {
        private ProcessDriver apacheDriver;
        private FileWatcher fileWatcher;

        public Apache()
        {
            apacheDriver = new ProcessDriver(Global.ApacheFile, "httpd.exe", "-f \"" + Global.Apache + "/conf/httpd.conf\"");
            apacheDriver.OutputTrigger += (ot, dt) => Console.WriteLine(@"{0}	{1}", ot, dt);

            fileWatcher = new FileWatcher(Global.SettingsRoot, "apache_*.cc");
            fileWatcher.FileChanged += path => { Global.Compiler.Compile(path); Restart();};
        }

        public void Start()
        {
            foreach (var file in Directory.GetFiles(Global.SettingsRoot, "apache_*.cc"))
            {
                Global.Compiler.Compile(file);
            }
            
            apacheDriver.Start();
        }

        public void Stop()
        {
            apacheDriver.Stop();
        }

        public void Restart()
        {
            apacheDriver.Restart();
        }
    }
}