using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CAMP.Utiles
{
    public class SettingsCompiler
    {
        private FieldInfo[] globalVars;
        public SettingsCompiler()
        {
            globalVars = typeof(Global).GetFields(BindingFlags.Static | BindingFlags.Public).Where(e => e.FieldType == typeof(string)).ToArray();
        }

        public void Compile(string file)
        {
            var conf = File.ReadAllText(file).Replace('\r', ' ');
            conf = globalVars.Aggregate(conf, (current, glob) => current.Replace("%" + glob.Name + "%", glob.GetValue(null).ToString()));
            var f = conf.Split('\n')[0].Remove(0, 1);
            conf = Regex.Replace(conf, @"^(#.*?|;.*?|\s*)$[\r\n]", "", RegexOptions.Multiline);
            File.WriteAllText(f, conf);
        }

    }
}