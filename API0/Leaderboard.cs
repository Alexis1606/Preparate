using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Data;

namespace API0
{
    public class Leaderboard
    {
        public static string get_leadboard(int examen)
        {
            string res = "";
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@id",examen)
            };

            DataTable dt = MSSql.ExecuteStoredProcedure(con, "sp_getleadboard", p);

            foreach (DataRow dr in dt.Rows)
            {
                res += dr[2].ToString() + "    "+ dr[1].ToString() + "    " + dr[0].ToString()+Environment.NewLine;
            }


            return res;
        }
    }
}
