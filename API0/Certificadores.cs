using Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{

    public class Certificadores
    {
        public int id;
        public string desc;

        public Certificadores(int id, string desc)
        {
            this.id = id;
            this.desc = desc;
        }
        public static string InsertCertificadores(string desc, string url)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@Desc", desc),
                 new Parameter("@url_oficial", url)
            };
            return Utilities.FirstDataFromTable(con, "InsertCertificadores", p);
        }

        public static void DeleteCertificadores(int id)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", id)
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "DeleteCertificadores", p));
        }
        public static Certificadores[] all()
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[] {
            };
            DataTable dt = MSSql.ExecuteStoredProcedure(con, "sp_obtenerCertificadores", p);
            Certificadores[] res = new Certificadores[dt.Rows.Count];
            for (int i = 0; i < res.Length; i++)
            {
                DataRow dr = dt.Rows[i];
                res[i] = new API0.Certificadores(Convert.ToInt32(dr["id"].ToString()), dr["descripcion"].ToString());
            }
            return res;
        }
    }
}
