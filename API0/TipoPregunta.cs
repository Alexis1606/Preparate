using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
   public class TipoPregunta
    {
        public static string InsertTipoPregunta(int ID, string desc)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", ID),
                 new Parameter("@Desc", desc)
            };
            return Utilities.FirstDataFromTable(con, "InsertTipoPregunta", p);
        }

        public static void DeleteTipoPregunta(int id)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", id)
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "DeleteTipoPregunta", p));
        }
    }
}
