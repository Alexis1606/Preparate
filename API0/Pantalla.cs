﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Data;

namespace API0
{
    public class Pantalla
    {
        public static string InsertPantalla(int ID, string desc)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", ID),
                 new Parameter("@Desc", desc)
            };
            return Utilities.FirstDataFromTable(con, "InsertPantallas", p);
        }

        public static void DeletePantalla(int id)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", id)
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "DeletePantallas", p));
        }
        public static int[] PantallasPorRol(int idRol)
        {
            ArrayList t = new ArrayList();
            int[] res;
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[] {

                 new Classes.Parameter("@idRol", idRol)
            };
            foreach(DataRow dr in MSSql.ExecuteStoredProcedure(con, "selectPantallaPorRol", p).Rows)
            {
                t.Add(dr[0]);
            }
            res = new int[t.Count];
            for(int i = 0; i < t.Count; i++)
            {
                res[i] = Convert.ToInt32(t[i]);
            }
            return res;

        }


    }
}
