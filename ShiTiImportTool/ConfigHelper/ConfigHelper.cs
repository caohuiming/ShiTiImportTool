using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiTiImportTool.ConfigHelper
{
    public class ConfigHelper
    {
        public static string GetApiRootUrl()
        {
            string strApiRootUrl= System.Configuration.ConfigurationManager.AppSettings["apiUrl"];
            return strApiRootUrl;
        }
    }
}
