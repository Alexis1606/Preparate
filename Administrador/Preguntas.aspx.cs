using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;

namespace Administrador
{
    public partial class Preguntas : System.Web.UI.Page
    {
        string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";

        protected void Page_Load(object sender, EventArgs e)
        {
            //--------------- Llenar Combo box Tipo Pregunta a partir de un Store de Select All
            Classes.Parameter[] p = new Classes.Parameter[] {
            };

            DataTable dt = MSSql.ExecuteStoredProcedure(con, "SelectAllTipoPregunta", p);

            foreach (DataRow dr in dt.Rows) {

                DDLTipo.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
            string x = DDLTipo.Items[0].ToString();
            DDLTipo.Items.Remove("Verdadero-falso");
            //--------------- Llenar Combo box Tipo Pregunta a partir de un Store de Select All

            //--------------- Llenar Combo box Examen a partir de un Store de Select All

            dt = MSSql.ExecuteStoredProcedure(con, "SelectAllExamen", p);

            foreach (DataRow dr in dt.Rows)
            {

                DDLExamen.Items.Add(new ListItem(dr[2].ToString(), dr[0].ToString()));
            }

            //--------------- Llenar Combo box Examen a partir de un Store de Select All

            //--------------- Llenar Combo box Tema a partir de un Store de Select All
            #region Tema
            dt = MSSql.ExecuteStoredProcedure(con, "SelectAllTema", p);

            foreach (DataRow dr in dt.Rows)
            {

                DDLTema.Items.Add(new ListItem(dr[1].ToString(), dr[0].ToString()));
            }
            #endregion
            //--------------- Llenar Combo box Tema a partir de un Store de Select All
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            TextBox[] Atxt = new TextBox[] {txtOpcCorrecta, txtOpc2, txtOpc3, txtOpc4, txtOpc5, txtOpc6, txtOpc7, txtOpc8, txtOpc9, txtOpc10 };
            string[] Opciones = new string[10];
            Random rm = new Random();
            int i = 0;
            int cont = 1;


            while (Atxt[i].Text != "")
            {
                i++;
            }
           int aleatorio = rm.Next(i - 1);

            Opciones[aleatorio] = Atxt[0].Text;

           
            for (int j =0; j < Opciones.Length; j++)
            {
                if(Opciones[j] == null)
                {
                    Opciones[j] = Atxt[cont].Text;
                    cont++;
                }
            }


        


            Classes.Parameter[] p = new Classes.Parameter[] {

                new Classes.Parameter ("@Pregunta",txtPregunta.Text),
                new Classes.Parameter ("@Opcion1",Opciones[0]),
                new Classes.Parameter ("@Opcion2",Opciones[1]),
                new Classes.Parameter ("@Opcion3",Opciones[2]),
                new Classes.Parameter ("@Opcion4",Opciones[3]),
                new Classes.Parameter ("@Opcion5",Opciones[4]),
                new Classes.Parameter ("@Opcion6",Opciones[5]),
                new Classes.Parameter ("@Opcion7",Opciones[6]),
                new Classes.Parameter ("@Opcion8",Opciones[7]),
                new Classes.Parameter ("@Opcion9",Opciones[8]),
                new Classes.Parameter ("@Opcion10",Opciones[9]),
                new Classes.Parameter ("@Respuesta_Correcta",aleatorio),
                new Classes.Parameter ("@Imagen",txtUrlImg.Text),
                new Classes.Parameter ("@ID_Tipo_Pregunta",DDLTipo.SelectedValue),
                new Classes.Parameter ("@Ayuda",txtAyuda.Text),
                new Classes.Parameter ("@ID_Tema",DDLTema.SelectedValue)

            };

            int ID = Convert.ToInt32(MSSql.FirstDataFromTable(con, "InsertPreguntas", p));

            p = new Classes.Parameter[] {
                new Classes.Parameter ("@ID_Pregunta",ID),
                new Classes.Parameter ("@ID_Examen",DDLExamen.SelectedValue)

            };

           MSSql.FirstDataFromTable(con, "InsertPreguntaExamen", p);

            Response.Write("<script LANGUAGE='JavaScript' >alert('Registro de Pregunta Exitoso')</script>");
        }

        protected void btnEnviarTema_Click(object sender, EventArgs e)
        {
            if (txtTema.Text != "")
            {
                //------------------Inserta un Tema
                Classes.Parameter[] p = new Classes.Parameter[] {

                new Classes.Parameter ("@Desc",txtTema.Text)

            };

                MSSql.FirstDataFromTable(con, "InsertTema", p);
                Response.Write("<script LANGUAGE='JavaScript' >alert('Registro de Tema Exitoso')</script>");
                //------------------Inserta un Tema
            }
            else {
                Response.Write("<script LANGUAGE='JavaScript' >alert('Si realmente deseas agrear un tema escrribelo sino dale click al botón de arriba')</script>");

            }
        }
    }
}