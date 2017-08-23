using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class StaticValues
    {
        static string conString;
        public static string CnnString
        {
            get
            {
                if(string.IsNullOrEmpty( conString))
                 conString = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
                return conString;
            }
        }

    }
}
