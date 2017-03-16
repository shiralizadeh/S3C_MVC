using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3C_MVC.Providers
{
    public static class ExM
    {
        public static string ToUrl(this string str)
        {
            return str.Replace(" ", "-");
        }
    }
}
