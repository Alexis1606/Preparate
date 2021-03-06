﻿using Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
    public class Estadisticas
    {
        public static string GetRespuestasCorrectasXUsuario(int idUsuario, int idExamen)
        {
            string res = "";
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@Id_Usuario",idUsuario),
                new Classes.Parameter("@Id_Examen",idExamen)
            };

            DataTable dt = MSSql.ExecuteStoredProcedure(con, "GetRespuestasCorrectasXUsuario", p);

            foreach (DataRow dr in dt.Rows)
            {
                res += dr[0].ToString()  + Environment.NewLine;
            }


            return res;
        }

        public static string GetPrsentajeCorrectasXUsuario(int idUsuario)
        {
            string res = "";
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@Id_Usuario",idUsuario)
            };

            DataTable dt = MSSql.ExecuteStoredProcedure(con, "GetPrsentajeCorrectasXUsuario", p);

            foreach (DataRow dr in dt.Rows)
            {
                res += dr[0].ToString() + '%' + Environment.NewLine;
            }


            return res;
        }


        public static string GetExamenesHechos(int idUsuario)
        {
            string res = "";
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@Id_Usuario",idUsuario)
            };

            DataTable dt = MSSql.ExecuteStoredProcedure(con, "GetExamenesHechos", p);

            foreach (DataRow dr in dt.Rows)
            {
                res += dr[0].ToString() +  Environment.NewLine;
            }


            return res;
        }

        public static string GetVecesRealizadasXExamen(int idUsuario, int idExamen)
        {
            string res = "";
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@Id_Usuario",idUsuario),
                new Classes.Parameter("@Id_Examen",idExamen)

            };

            DataTable dt = MSSql.ExecuteStoredProcedure(con, "GetVecesRealizadasXExamen", p);

            foreach (DataRow dr in dt.Rows)
            {
                res += dr[0].ToString() + Environment.NewLine;
            }


            return res;
        }

        public static string GetPorcentajeTemamenor80(int idUsuario)
        {
            string res = "";
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@Id_Usuario",idUsuario)

            };

            DataTable dt = MSSql.ExecuteStoredProcedure(con, "GetPorcentajeTemamenor80", p);

            foreach (DataRow dr in dt.Rows)
            {
                res += dr[0].ToString() + " " + dr[1].ToString() + " %" + Environment.NewLine;
            }


            return res;
        }

        public static string GetPorcentajeTemamenor80CCNA(int idUsuario)
        {
            string res = "";
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@Id_Usuario",idUsuario)

            };

            DataTable dt = MSSql.ExecuteStoredProcedure(con, "GetPorcentajeTemamenor80CCNA", p);

            foreach (DataRow dr in dt.Rows)
            {
                res += dr[0].ToString() + " " + dr[1].ToString() + " %" + Environment.NewLine;
            }


            return res;
        }


        public static string GetPorcentajeTemamenor80ORACLE(int idUsuario)
        {
            string res = "";
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@Id_Usuario",idUsuario)

            };

            DataTable dt = MSSql.ExecuteStoredProcedure(con, "GetPorcentajeTemamenor80ORACLE", p);

            foreach (DataRow dr in dt.Rows)
            {
                res += dr[0].ToString() + " " + dr[1].ToString() + " %" + Environment.NewLine;
            }


            return res;
        }
    }
}
