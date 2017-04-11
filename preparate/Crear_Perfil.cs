using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace preparate
{
    [Activity(Label = "Crear Perfil", Icon = "@drawable/Icon")]

    public class Crear_Perfil : Activity
    {
        EditText txtNombre;
        EditText txtApellidos;
        EditText txtEmail;

        EditText txtFechaNac;
        TextView textoGenero;

        RadioButton GeneroMasculino;

        EditText tContra1;
        EditText tContra2;



        Button bValidar;

        //String nombre;
        //string apellidos;
        //string usuario;
        string contra1;
        string contra2;





        //int id = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Crear_Perfil);



            txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            txtApellidos = FindViewById<EditText>(Resource.Id.txtApellidos);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtFechaNac = FindViewById<EditText>(Resource.Id.txtFechaNac);
            textoGenero = FindViewById<TextView>(Resource.Id.textoGenero);
            GeneroMasculino = FindViewById<RadioButton>(Resource.Id.GeneroMasculino);
            tContra1 = FindViewById<EditText>(Resource.Id.tContra1);
            tContra2 = FindViewById<EditText>(Resource.Id.tContra2);

            bValidar = FindViewById<Button>(Resource.Id.ok);





            bValidar.Click += BValidar_Click;
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //Spinner spinner = (Spinner)sender;

            //string toast = string.Format("Escuela: {0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
        }

        private void BValidar_Click(object sender, EventArgs e)
        {
            //StartActivity(typeof(MenuPrincipal));

            int genero;

            if (validar_contra())

            {

                if (GeneroMasculino.Selected)

                {

                    genero = 1;



                }

                else

                {

                    genero = 0;

                }

                try

                {





                    API0.User.InsertUser(txtNombre.Text, txtApellidos.Text, "", Convert.ToDateTime(txtFechaNac.Text), tContra1.Text, txtEmail.Text, genero, 1, 1, "a");

                }

                catch (Exception ex)

                {

                    string x = ex.ToString();

                    int x1 = 0;



                }

            }



        }

        //private void BValidar_Click(object sender, EventArgs e)
        //{
        //    obtener_datos();
        //    if (validar_contra() && validar_EditText(tNombre) && validar_EditText(tApellidos) && validar_EditText(tCorreo))
        //    {
        //        MySqlConnection con = new MySqlConnection("Server=alexis.c2g7lahthau8.us-east-1.rds.amazonaws.com;Port=3306; database=FarNext;User Id=juanLuis;Password=IngConocimiento123;charset=utf8");
        //        try
        //        {

        //            if (con.State == ConnectionState.Closed)
        //            {
        //                con.Open();
        //                MySqlCommand cmd = new MySqlCommand("Insert into usuario (Nombre,Apellidos,Correo,Contrasena) values (@nombre, @apellidos,@correo,@pass)", con);
        //                cmd.Parameters.AddWithValue("@nombre", tNombre.Text);
        //                cmd.Parameters.AddWithValue("@apellidos", tApellidos.Text);
        //                cmd.Parameters.AddWithValue("@correo", tCorreo.Text);
        //                cmd.Parameters.AddWithValue("@pass", tContra1.Text);
        //                cmd.ExecuteNonQuery();
        //                Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
        //                AlertDialog alertDialog = builder.Create();
        //                alertDialog.SetTitle("Mensaje");
        //                alertDialog.SetIcon(Resource.Drawable.Icon);
        //                alertDialog.SetMessage("Registro Exitoso");
        //                alertDialog.SetButton("OK", (s, ev) =>
        //                {
        //                    StartActivity(typeof(MenuTemp));
        //                });
        //                alertDialog.Show();


        //            }
        //        }
        //        catch (MySqlException ex)
        //        {
        //            Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
        //            AlertDialog alertDialog = builder.Create();
        //            alertDialog.SetTitle("Mensaje");
        //            alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
        //            alertDialog.SetMessage("Falló el registro");
        //            alertDialog.SetButton("OK", (s, ev) =>
        //            {
        //                StartActivity(typeof(MenuTemp));
        //            });
        //            alertDialog.Show();
        //        }
        //        finally
        //        {
        //            con.Close();
        //        }


        //    }
        //}

        public void obtener_datos()
        {
            #region Obtiene los datos de los textbox
            //tNombre = FindViewById<EditText>(Resource.Id.tNombre);
            //tApellidos = FindViewById<EditText>(Resource.Id.tApellidos);
            //tusuario = FindViewById<EditText>(Resource.Id.tusuario);            
            tContra1 = FindViewById<EditText>(Resource.Id.tContra1);
            tContra2 = FindViewById<EditText>(Resource.Id.tContra2);

            //nombre = tNombre.Text;
            //apellidos = tApellidos.Text;
            //usuario = tusuario.Text;

            contra1 = tContra1.Text;
            contra2 = tContra2.Text;


            #endregion
        }

        public bool validar_contra()
        {
            bool v = false;
            if (contra1 == contra2)
                v = true;
            else
            {
                tContra1.SetBackgroundColor(Android.Graphics.Color.Red);
                tContra2.SetBackgroundColor(Android.Graphics.Color.Red);
                Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
                AlertDialog alertDialog = builder.Create();
                alertDialog.SetTitle("Mensaje");
                alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                alertDialog.SetMessage("Las contraseñas NO coinciden, Intentalo de nuevo.");
                alertDialog.SetButton("OK", (s, ev) =>
                {

                });
                alertDialog.Show();



            }

            return v;
        }

        public bool validar_EditText(EditText t)
        {
            bool v = false;
            if (t.Text == "" || t.Text == null)
            {
                t.SetBackgroundColor(Android.Graphics.Color.Orange);

            }
            else
            {
                v = true;
            }
            return v;
        }
    }
}