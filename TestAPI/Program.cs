using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API0;
using System.Configuration;

namespace TestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Menu*****");
            Console.WriteLine("Usuarios");
            Console.WriteLine("1.- Alta usuario");//login
            Console.WriteLine("2.- Baja usuario");//administraci[on(superusuario)
            Console.WriteLine("3.- Login (Solo estatus de si o no)");
            Console.WriteLine("4.- Perfil (login -> mostrar datos del usuario)");
            Console.WriteLine("Roles");
            Console.WriteLine("5.- Alta rol");//administraci[on superusuario
            Console.WriteLine("6.- Baja usuario");//administraci[on superusuario
            Console.WriteLine("7.- Mostrar roles");//administracion, alta usuario
            Console.WriteLine("8.- Mostrar rol de un usuario (numerico)");//Definir que pantallas se van a mostrar, si es gratuito o no
            Console.WriteLine("Pantallas");
            Console.WriteLine("9.- Alta pantalla");//administraci[on superusuario
            Console.WriteLine("10.- Baja pantalla");//administraci[on superusuario
            Console.WriteLine("11.- Mostrar pantallas por rol (arreglo numerico)");//Definir que pantallas se van a mostrar
            Console.WriteLine("Preguntas");
            Console.WriteLine("12.- Alta pregunta");
            Console.WriteLine("13.- Baja pregunta");
            Console.WriteLine("14.- Pregunta aleatoria(solo mostrar)");//no la va a poder contestar
            Console.WriteLine("15.- Contestar pregunta sin dato (Mostrar -> validar respuesta -> Guardar respuesta usuario)");//para todos los tipos de examen//se va a validar el tipo de pregunta y con esto es la forma en que se muestra
            Console.WriteLine("16.- Contestar pregunta con dato (Mostrar -> validar respuesta -> Guardar respuesta usuario)");//para todos los tipos de examen
            Console.WriteLine("17.- Alta tipo pregunta");
            Console.WriteLine("18.- Baja tipo pregunta");
            Console.WriteLine("19.- Alta tema pregunta");
            Console.WriteLine("20.- Baja tema pregunta");
            Console.WriteLine("21.- ver tema pregunta"); // en configuraci[on de examen poder seleccionar unicamente de que tema se quieren preguntas
            Console.WriteLine("22.- Mostrar tabla respuestas usuarios");// solo como muestra de que funciona
            Console.WriteLine("Examenes");
            Console.WriteLine("23.- Insertar tipo examen");
            Console.WriteLine("24.- Baja tipo examen");
            Console.WriteLine("25.- Insertar examen");
            Console.WriteLine("26.- Baja examen");
            Console.WriteLine("27.- Insertar certificador");
            Console.WriteLine("28.- eliminar certificador");
            Console.WriteLine("29.- Mostrar tipos examenes");//para configuraci[on de examen poder filtrar mejor los examenes
            Console.WriteLine("30.- Mostrar todos los examenes");
            Console.WriteLine("31.- Mostrar examenes por tipo de examen");
            Console.WriteLine("30.- Mostrar todos los certificadores");
            Console.WriteLine("31.- Mostrar examenes por certificador");
            Console.WriteLine("32.- Mostrar todas Las preguntas de un examen");
            Console.WriteLine("33.- Mostrar una pregunta de un examen");

            int opc = Convert.ToInt32(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    Console.WriteLine("Ingresa el Nombre");
                    string Nombre = Console.ReadLine();
                    Console.WriteLine("Ingresa el Apellido Parteno");
                    string Apellido_Parterno = Console.ReadLine();
                    Console.WriteLine("Ingresa el Apellido Materno");
                    string Apellido_Materno = Console.ReadLine();
                    Console.WriteLine("Ingresa el Fecha Nacimiento");
                    DateTime Fecha_Nacimiento =Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Ingresa la contraseña");
                    string Password_Hash = Utilities.encrypt(Console.ReadLine());
                    Console.WriteLine("Ingresa el Correo");
                    string Correo = Console.ReadLine();
                    Console.WriteLine("Ingresa 1 = Hombre 0 = Mujer");
                    int Genero =Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa el Rol en numero");
                    int ID_Rol =Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa el Estatus en numero");
                    int ID_Estatus = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa el Hash de la foto");
                    string Hash_Foto = Console.ReadLine();

                    Console.WriteLine(API0.User.InsertUser(Nombre, Apellido_Parterno, Apellido_Materno, Fecha_Nacimiento, Password_Hash, Correo, Genero, ID_Rol, ID_Estatus, Hash_Foto));
                    break;

                case 2:
                    Console.WriteLine("Ingresa el ID a eliminar");
                    int ID = Convert.ToInt32(Console.ReadLine());
                    User.DeleteUser(ID);
                    Console.WriteLine("Usuario eliminado");
                    break;
                case 3:
                    Console.WriteLine("Ingresa el correo del usuario");
                    string correo = Console.ReadLine();
                    Console.WriteLine("Ingresa el pass del usuario");
                    string pass = Utilities.encrypt(Console.ReadLine());
                    Console.WriteLine("Hola usuario ");
                    User.Login(correo,pass);
                   
                    break;
                case 4:
                    Console.WriteLine("Ingresa el ID del usuario");
                    int IDUsuario = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Hola usuario ");
                    User.SelectAlUsers(IDUsuario);
                    break;
                case 5:
                    Console.WriteLine("Ingresa el Id del rol");
                    int IDRol = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa la descripcion del rol");
                    string desc = Console.ReadLine();
                    Console.WriteLine(Roles.InsertRol(IDRol, desc));
                    break;
                case 6:
                    Console.WriteLine("Ingresa el Id del rol que deseas eliminar");
                    int IDRolE = Convert.ToInt32(Console.ReadLine());
                    Roles.DeleteRol(IDRolE);
                    Console.WriteLine("Rol eliminado");
                    break;
                case 7:
                    Console.WriteLine("Estos son los roles");
                    Roles.SelectAllRoles();
                    break;
                case 8:
                    Console.WriteLine("Ingresa el ID del Usuario");
                    IDUsuario = Convert.ToInt32(Console.ReadLine());
                    Roles.RolUsuario(IDUsuario);
                    break;
                case 9:
                    Console.WriteLine("Ingresa el ID de la pantalla");
                    int IDPantalla = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa la descripcion de la pantalla");
                    string descPantalla = Console.ReadLine();
                    Console.WriteLine(Pantalla.InsertPantalla(IDPantalla, descPantalla));
                    break;
                case 10:
                    Console.WriteLine("Ingresa el ID de la pantalla");
                     IDPantalla = Convert.ToInt32(Console.ReadLine());
                    Pantalla.DeletePantalla(IDPantalla);
                    Console.WriteLine("Pantalla eliminada");
                    break;
                case 11:

                    break;
                case 12:

                    break;
                case 13:

                    break;
                case 14:

                    break;
                case 15:

                    break;
                case 16:

                    break;

                case 17:
                    Console.WriteLine("Ingresa el ID del tipo de pregunta");
                    int IDTIpoPregunta = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa la descripcion de la pantalla");
                    string descTipoPregunta = Console.ReadLine();
                    Console.WriteLine(TipoPregunta.InsertTipoPregunta(IDTIpoPregunta, descTipoPregunta));
                    break;
                case 18:
                    Console.WriteLine("Ingresa el ID del Tipo de Pregunta");
                    int IDTipoPregunta = Convert.ToInt32(Console.ReadLine());
                    Pantalla.DeletePantalla(IDTipoPregunta);
                    Console.WriteLine("Tipo Pregunta eliminada");
                    break;
                case 19:

                    break;
                case 20:

                    break;
                case 21:

                    break;
                case 22:

                    break;
                case 23:
                    Console.WriteLine("Ingresa la descripcion del tipo de examen");
                    string descTipoExamen = Console.ReadLine();
                    Console.WriteLine(TipoExamen.InsertTipoExamen(descTipoExamen));
                    break;
                case 24:
                    Console.WriteLine("Ingresa el ID del Tipo de Examen");
                    int IDTipoExamen = Convert.ToInt32(Console.ReadLine());
                    Pantalla.DeletePantalla(IDTipoExamen);
                    Console.WriteLine("Tipo Examen eliminado");
                    break;
                case 25:
                    Console.WriteLine("Ingresa la descripcion del Examen");
                    string descExamen = Console.ReadLine();
                    Console.WriteLine("Ingresa el nombre del Examen");
                    string nombreExamen = Console.ReadLine();
                    Console.WriteLine("Ingresa el ID_Certificador del Examen");
                    int IDCertificador = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa el Tiempo del Examen");
                    int tiempo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa el ID_Tipo_Examen del Examen");
                    int ID_Tipo_Examen = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa el Url_Oficial del Examen");
                    string UrlExamen = Console.ReadLine();

                    Console.WriteLine(Examen.InsertExamen(descExamen,nombreExamen,IDCertificador,tiempo,ID_Tipo_Examen, UrlExamen));
                    break;

                case 26:

                    break;
                case 27:
                    Console.WriteLine("Ingresa la Descrición del Certificador");
                    string DescCertificador = Console.ReadLine();
                    Console.WriteLine("Ingresa la URl del Certificador");
                    string Url = Console.ReadLine();
                    Console.WriteLine(Certificadores.InsertCertificadores(DescCertificador, Url));
                    break;
                case 28:
                    Console.WriteLine("Ingresa el ID del Certificador");
                    int IDCertificadorE = Convert.ToInt32(Console.ReadLine());
                    Certificadores.DeleteCertificadores(IDCertificadorE);
                    Console.WriteLine("Certificador eliminado");
                    break;
                case 29:

                    break;
                case 30:

                    break;
                case 31:

                    break;
                case 32:

                    break;
                case 33:

                    break;
             
            }

            //Console.WriteLine("Estad[isticas (Pendiente, se trabajar[a cuando se haga el BI)");

            //string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            //Parameter[] p = new Parameter[] { new Parameter("@name","Alexis")};
            //String res = Utilities.FirstDataFromTable(con, "hola", p);
            //Console.WriteLine(res);
            Console.ReadLine();

        }

        //public static string altaUsuario()
        //{
        //    //ejecutar query
        //    return "Lo que regresa el query";
        //}
    }
}
