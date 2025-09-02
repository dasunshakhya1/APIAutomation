using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configs
{
    public class ApplicationConfigs
    {
        public static string BASE_URL = Environment.GetEnvironmentVariable("BASE_URL") ?? "https://api.restful-api.dev";
    }
}
