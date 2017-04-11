using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API0
{
    public class User
    {
        private string Nombre;
        private string Apellido_Parterno;
        private string Apellido_Materno;
        private DateTime Fecha_Nacimiento;
        private string Password_Hash;
        private string Correo;
        private int Genero;
        private int ID_Rol;
        private int ID_Estatus;
        private string Hash_Foto;

        public static string InsertUser(string nombre, string apellido_paterno, string apellido_materno, DateTime fecha_nacimiento, string password_hash, string correo, int genero, int id_rol, int id_estatus, string hash_foto)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";

            Parameter[] p = new Parameter[] {
                 new Parameter("@Nombre", nombre),
                 new Parameter("@Apellido_Paterno", apellido_paterno),
                 new Parameter("@Apellido_Materno", apellido_materno),
                 new Parameter("@Fecha", fecha_nacimiento),
                 new Parameter("@Password_Hash", Utilities.encrypt(password_hash)),
                 new Parameter("@Correo", correo),
                 new Parameter("@Genero", genero),
                 new Parameter("@ID_Rol", id_rol),
                 new Parameter("@ID_Estatus", id_estatus),
                 new Parameter("@Hash_Foto", hash_foto)
            };
            
            return Utilities.FirstDataFromTable(con, "InsertUsuarios", p);
        }

        public static void DeleteUser(int ID)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", ID)
            };
            Console.WriteLine(Utilities.ExecuteStoredProcedure(con, "DeleteUsuarios", p));
        }


        public static void Login(string correo, string pass)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@Correo", correo),
                 new Parameter("@Pass", pass)
            };

            Console.WriteLine(Utilities.FirstDataFromTable(con, "LoginUsuarios", p));

        }

        public static void SelectAlUsers(int ID)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Parameter[] p = new Parameter[] {

                 new Parameter("@ID", ID)
            };
            Console.WriteLine(Utilities.FirstDataFromTable(con, "SelectByIDUsuarios", p));
        }

        public static string signup(string mail, string password)
        {
            string res="";
            password = Utilities.encrypt(password);
            return res;
        }


    }
}
