using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
    public class Roles
    {
        public static string InsertRol (int id, string desc)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", id),
                 new Parameter("@Desc", desc)
            };
           return Utilities.FirstDataFromTable(con, "InsertRoles", p);
        }

        public static void DeleteRol(int id)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", id)
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "DeleteRoles", p));
        }

        public static void SelectAllRoles()
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "SelectAllRoles", p)); 
        }

        public static void RolUsuario(int ID)
        {
            string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", ID)
            };
            Console.WriteLine(Utilities.DataFromTable(con, "SelectByIDRoles", p));
        }
    }
}
