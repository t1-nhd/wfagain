using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class StaticResource
    {
        private static readonly string cString = "Data Source=HDUYSTRIX;Initial Catalog=NhatNamFood;Integrated Security=True;TrustServerCertificate=True";

        public static string vndMoneyFormat(decimal value) { 
            return value.ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";
        }
    
        public static string connectionString()
        {
            return cString;
        }
    }
}
