using System.Windows.Forms;

namespace CAMP.Utiles
{
    public static class Global
    {
        public static SettingsCompiler Compiler = new SettingsCompiler();

        public static string BaseRoot = Application.StartupPath.Replace('\\','/');
        public static string SettingsRoot = BaseRoot + "/settings";
        public static string DocumentRoot = BaseRoot + "/www";
        public static string System = BaseRoot + "/system";
        public static string Temp = BaseRoot + "/temp";
        public static string Logs = Temp + "/logs";
        public static string Sessions = Temp + "/sessions";
        public static string Apache = System + "/apache";
        public static string Php = System + "/php";
        public static string Mysql = System + "/mysql";
        public static string Apps = System + "/apps";

        public static string PhpFile = Php + "/7.0.3";
        public static string MysqlFile = Mysql + "/5.7.11";
        public static string ApacheFile = Apache + "/2.4.18";
    }
}