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
    //
    [Activity(Label = "Acceder")]
    public class Acceder : Activity
    {
        EditText Correo;
        EditText Contrasena;
        Button bAcceder;

        string correo2;
        string contrasena2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Acceder);
            Correo = FindViewById<EditText>(Resource.Id.txtEmail);
            Contrasena = FindViewById<EditText>(Resource.Id.txtPassword);
            bAcceder = FindViewById<Button>(Resource.Id.OK);
            bAcceder.Click += bAcceder_Click;

            // Create your application here

        }

        private void bAcceder_Click(object sender, EventArgs e)
        {
            int numUsuario;
            if (validar_EditText(Correo) && validar_EditText(Contrasena))
            {
                correo2 = Correo.Text;
                contrasena2 = Contrasena.Text;
                numUsuario = API0.User.login(correo2, contrasena2);
                if (numUsuario == 0)
                {
                    Android.App.AlertDialog.Builder build = new AlertDialog.Builder(this);
                    AlertDialog alertDialog = build.Create();
                    alertDialog.SetTitle("Mensaje");
                    alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                    alertDialog.SetMessage("Parece que hubo un error al intentar iniciar sesión");
                    alertDialog.SetButton("OK", (s, ev) =>
                    {
                        StartActivity(typeof(Acceder));
                    });
                    alertDialog.Show();
                }
                else
                {
                    appCode.ChangeLoginStatus(this, 1);
                    appCode.SaveUser(this, numUsuario);
                    StartActivity(typeof(MenuPrincipal));
                }
            }
        }

        public bool validar_EditText(EditText t)
        {
            bool v = false;
            if (t.Text == "" || t.Text == null)
            {
                t.SetBackgroundColor(Android.Graphics.Color.Orange);
                Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
                AlertDialog alertDialog = builder.Create();
                alertDialog.SetTitle("Acceder");
                alertDialog.SetMessage("Te faltan algunos campos !");
                alertDialog.SetButton("OK", (s, ev) =>
                {
                });
                alertDialog.Show();
            }

            else
            {
                v = true;
            }
            return v;
        }
    }
}