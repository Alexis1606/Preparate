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
                    Console.WriteLine(altaUsuario());
                    break;
            }

            //Console.WriteLine("Estad[isticas (Pendiente, se trabajar[a cuando se haga el BI)");

            //string con = ConfigurationManager.ConnectionStrings["Preparate"].ToString();
            //Parameter[] p = new Parameter[] { new Parameter("@name","Alexis")};
            //String res = Utilities.FirstDataFromTable(con, "hola", p);
            //Console.WriteLine(res);
            Console.ReadLine();

        }

        public static string altaUsuario()
        {
            //ejecutar query
            return "Lo que regresa el query";
        }
    }
}
