using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
    public class Certificadores
    {
        public static string InsertCertificadores(string desc, string url)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@Desc", desc),
                 new Parameter("@url_oficial", url)
            };
            return Utilities.FirstDataFromTable(con, "InsertCertificadores", p);
        }

        public static void DeleteCertificadores(int id)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", id)
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "DeleteCertificadores", p));
        }
    }
}
