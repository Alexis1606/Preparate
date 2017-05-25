using Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
    public class InicioSesion
    {
        public static void InsertInicioSesion(int ID_Usuario)
        {
            string res = "";
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@Id_Usuario",ID_Usuario)
            };

            DataTable dt = MSSql.ExecuteStoredProcedure(con, "InsertInicioSesion", p);
        }

    }
}
