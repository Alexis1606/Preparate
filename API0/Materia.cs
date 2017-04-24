using Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
    public class Materia
    {
        public int id;
        public string desc;

        public Materia(int id, string desc)
        {
            this.id = id;
            this.desc = desc;
        }

        public static Materia[] all()
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[] {
            };
            DataTable dt = MSSql.ExecuteStoredProcedure(con, "sp_obtenerMaterias", p);
            Materia[] res = new Materia[dt.Rows.Count];
            for (int i = 0; i < res.Length; i++)
            {
                DataRow dr = dt.Rows[i];
                res[i] = new API0.Materia(Convert.ToInt32(dr["id"].ToString()), dr["descripcion"].ToString());
            }
            return res;
        }


    }
}
