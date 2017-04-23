using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace API0
{
    public class User
    {
        public string Nombre;
        public string Apellido_Parterno;
        public string Apellido_Materno;
        public string Fecha_Nacimiento;
        private string Password_Hash;
        public string Correo;
        public int Genero;
        private int ID_Rol;
        private int ID_Estatus;
        private string Hash_Foto;


        public User(int id)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";

            Classes.Parameter[] p = new Classes.Parameter[] {
                 new Classes.Parameter("@id", id)
            };
            DataTable dt = MSSql.ExecuteStoredProcedure(con, "sp_getUserInfo",p);
            DataRow dr = dt.Rows[0];
            this.Nombre = dr["nombre"].ToString();
            this.Apellido_Parterno = dr["apellidos"].ToString();
            this.Correo=dr["correo"].ToString();
            this.Fecha_Nacimiento = dr["fecha_nacimiento"].ToString();

            String prueba=dr["genero"].ToString();
            if (dr["genero"].ToString()=="False")
            {
                this.Genero = 0;
            }
            else
            {
                this.Genero = 1;
            }
            //this.Genero = Convert.ToInt32(dr["genero"].ToString());
        }

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

        public static int login(string mail, string password)
        {
            int res = 0;
            password = Utilities.encrypt(password);
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[] {

                 new Classes.Parameter("@correo", mail),
                 new Classes.Parameter("@pwdHash", password)
            };
            res = Convert.ToInt32(Classes.MSSql.FirstDataFromTable(con, "LoginUsuarios", p));
            return res;
        }

        public static string UpdatetUser(int  id, string nombre, string apellido_paterno, DateTime fecha_nacimiento, string correo, int genero)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";

            Parameter[] p = new Parameter[] {
                 new Parameter("@id", id),
                 new Parameter("@nombre", nombre),
                 new Parameter("@apellido_Paterno", apellido_paterno),
                 new Parameter("@fecha", fecha_nacimiento),
                 new Parameter("@correo", correo),
                 new Parameter("@genero", genero),
                 
            };

            return Utilities.FirstDataFromTable(con, "sp_updateInfo", p);
        }

    }
}
