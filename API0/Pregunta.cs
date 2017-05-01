using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Configuration;
using System.Data;

namespace API0
{
    public class Pregunta
    {
        public string pregunta;
        public string[] opciones;
        public int opcCorrecta;
        public int idPregunta;
        public string imagen;
        public int tipo;
        public string ayuda;
        

        public Pregunta(string pregunta,string[] opciones,int opcCorrecta,int idPregunta,string imagen,int tipo, string ayuda)
        {
            this.pregunta = pregunta;
            this.opciones = opciones;
            this.opcCorrecta = opcCorrecta;
            this.idPregunta = idPregunta;
            this.imagen = imagen;
            this.tipo = tipo;
            this.ayuda = ayuda;

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

        public static Pregunta obtenerAleatoria(int examen)
        {
            string[] opciones;
            int cOpciones = 2;

            string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
            Classes.Parameter[] p = new Classes.Parameter[]
            {
                new Classes.Parameter("@examen",examen)
            };
            DataTable pre = MSSql.ExecuteStoredProcedure(con, "sp_randomQuestion", p);
            DataRow dr = pre.Rows[0];
            while (dr[cOpciones].ToString() != "" && cOpciones <= 11)
            {
                cOpciones++;
            }

            cOpciones -= 1;

            opciones = new String[cOpciones -1];

            for(int i=2;i<=cOpciones; i++)
            {
                opciones[i - 2] = dr["opcion" + (i-1)].ToString();
            }
            return new Pregunta(dr[1].ToString(), opciones, Convert.ToInt32(dr[12].ToString()), Convert.ToInt32(dr[0].ToString()), dr[13].ToString(), Convert.ToInt32(dr[14].ToString()), dr[15].ToString());

        }
    }
}
