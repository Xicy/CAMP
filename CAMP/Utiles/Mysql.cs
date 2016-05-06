using System;
using System.IO;

namespace CAMP.Utiles
{
    public class Mysql
    {
        private ProcessDriver mysqlDriver;
        private FileWatcher fileWatcher;

        public Mysql()
        {
            mysqlDriver = new ProcessDriver(Global.MysqlFile, "mysqld.exe", "--defaults-file=\"" + Global.Mysql + "/my.ini\" --console");
            mysqlDriver.OutputTrigger += (ot, dt) => Console.WriteLine(@"{0}	{1}", ot, dt);

            fileWatcher = new FileWatcher(Global.SettingsRoot, "mysql_*.cc");
            fileWatcher.FileChanged += path => { Global.Compiler.Compile(path); Restart();};
        }

        public static Mysql Initialize()
        {
            var mysqlDriver = new ProcessDriver(Global.MysqlFile, "mysqld.exe", "--defaults-file=\"" + Global.Mysql + "/my.ini\" --console --initialize-insecure --user=root");
            mysqlDriver.OutputTrigger += (ot, dt) => Console.WriteLine(@"{0}	{1}", ot, dt);
            mysqlDriver.Start();
            mysqlDriver.WaitForExit();
            return new Mysql();
        }

        public void Start()
        {
            foreach (var file in Directory.GetFiles(Global.SettingsRoot, "mysql_*.cc"))
            {
                Global.Compiler.Compile(file);
            }

            mysqlDriver.Start();
        }

        public void Stop()
        {
            mysqlDriver.Stop();
        }

        public void Restart()
        {
            mysqlDriver.Restart();
        }
    }
}