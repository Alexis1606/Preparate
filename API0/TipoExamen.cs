using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Data;

namespace API0
{
    public class TipoExamen
    {

        public int id;
        public  string desc;

        public TipoExamen(int id,string desc)
        {
            this.id = id;
            this.desc = desc;
        }

        public static string InsertTipoExamen(string desc)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@Desc", desc)
            };
            return Utilities.FirstDataFromTable(con, "InsertTipoExamen", p);
        }

        public static void DeleteTipoExamen(int id)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", id)
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "DeleteTipoExamen", p));
        }

        public static TipoExamen[] all()
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[] {
            };
            DataTable dt = MSSql.ExecuteStoredProcedure(con, "sp_obtenerTiposExamen", p);
            TipoExamen[] res = new TipoExamen[dt.Rows.Count];
            for(int i = 0; i < res.Length; i++)
            {
                DataRow dr = dt.Rows[i];
                res[i] = new API0.TipoExamen(Convert.ToInt32(dr["id"].ToString()), dr["descripcion"].ToString());
            }
            return res;
        }
    }
}
