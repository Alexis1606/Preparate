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
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", ID),
                 new Parameter("@Desc", desc)
            };
            return Utilities.FirstDataFromTable(con, "InsertTipoPregunta", p);
        }

        public static void DeleteTipoPregunta(int id)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", id)
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "DeleteTipoPregunta", p));
        }
    }
}
