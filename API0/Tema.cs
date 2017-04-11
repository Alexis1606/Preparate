using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Configuration;
using System.Collections;
using System.Data;

namespace API0
{
    public class Tema
    {
        public int id;
        public string descripcion;

        public Tema(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public static string alta_tema(string descripcion)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@Desc",descripcion)
            };
            return MSSql.FirstDataFromTable(con, "InsertTema", p);
        }

        public static int baja_tema(int id)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@ID",id)
            };
            try
            {
                return Convert.ToInt32(MSSql.FirstDataFromTable(con, "DeleteTema", p));
            }catch(Exception ex)
            {
                return 0;
            }
            
        }


        public static Tema[] obtener_Temas()
        {
            ArrayList temp = new ArrayList();
            Tema[] t ;
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
            };
            foreach (DataRow dr in MSSql.ExecuteStoredProcedure(con, "SelectAllTema", p).Rows)
            {
                temp.Add(new Tema(Convert.ToInt32(dr[0].ToString()), dr[1].ToString()));
            }
            t = new Tema[temp.Count];
            for(int i=0;i<temp.Count;i++)
            {
                t[i] = (Tema)temp[i];
            }
            return t;


        } 



    }
}
