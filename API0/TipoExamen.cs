using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
    public class TipoExamen
    {
        public static string InsertTipoExamen(string desc)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@Desc", desc)
            };
            return Utilities.FirstDataFromTable(con, "InsertTipoExamen", p);
        }

        public static void DeleteTipoExamen(int id)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", id)
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "DeleteTipoExamen", p));
        }
    }
}
