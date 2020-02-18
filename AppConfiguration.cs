using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearSystemsSolutions
{
    class AppConfiguration
    {
        AppConfiguration()
        {
           
        }

        public static void saveConfig(string sLlave, string sValor)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(sLlave);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            config.AppSettings.Settings.Add(sLlave, sValor);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string getConfig(string sLlave)
        {
            string sRetorno = ConfigurationManager.AppSettings[sLlave];
            if (sRetorno == null) return "";
            return sRetorno;
        }
    }
}
