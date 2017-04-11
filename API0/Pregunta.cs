using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Configuration;

namespace API0
{
    public class Pregunta
    {
        string pregunta;
        string[] opciones;
        int opcCorrecta;

        public Pregunta()
        {

        }
        public static int altaPregunta(String pregunta,string[] opciones,int rcorrecta,int tipoPregunta,String ayuda,int tema, string urlImagen)
        {
            Classes.Parameter[] p = new Classes.Parameter[opciones.Length+6];
            p[0] = new Classes.Parameter("@Pregunta", pregunta);
            p[1] = new Classes.Parameter("@Respuesta_Correcta", rcorrecta);
            p[2] = new Classes.Parameter("@ID_Tipo_Pregunta", tipoPregunta);
            p[3] = new Classes.Parameter("@Ayuda", ayuda);
            p[4] = new Classes.Parameter("@ID_Tema", tema);
            p[5] = new Classes.Parameter("@Imagen", pregunta);
            for (int i = 0; i < opciones.Length; i++)
            {
               
                    p[i+6] = new Classes.Parameter("@Opcion" + (i+1), opciones[i]);
               
            }
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            return Convert.ToInt32(MSSql.FirstDataFromTable(con, "InsertPreguntas", p));
        }
        public static int altaPregunta(String pregunta,string[] opciones,int rcorrecta,int tipoPregunta,String ayuda,int tema)
        {
            Classes.Parameter[] p = new Classes.Parameter[opciones.Length + 5];
            p[0] = new Classes.Parameter("@Pregunta", pregunta);
            p[1] = new Classes.Parameter("@Respuesta_Correcta", rcorrecta);
            p[2] = new Classes.Parameter("@ID_Tipo_Pregunta", tipoPregunta);
            p[3] = new Classes.Parameter("@Ayuda", ayuda);
            p[4] = new Classes.Parameter("@ID_Tema", tema);
            for (int i = 0; i < opciones.Length; i++)
            {

                p[i + 5] = new Classes.Parameter("@Opcion" + (i + 1), opciones[i]);

            }
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            return Convert.ToInt32(MSSql.FirstDataFromTable(con, "InsertPreguntas", p));
        }
        public static int baja(int id)
        {
            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@ID",id)
            };
            return Convert.ToInt32(MSSql.FirstDataFromTable(con, "DeletePreguntas", p));
        }

    }
}
