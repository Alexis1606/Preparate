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
    [Activity(Label = "Configuración")]
    public class Configuracion : Activity
    {
        ImageView Modificar;
        ImageView Acerca;
        ImageView Aviso;        
        //Button bUnirse;
        TextView CerrarSesion;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Configuracion);
            //bUnirse = FindViewById<Button>(Resource.Id.bUnirse);
            Acerca = FindViewById<ImageView>(Resource.Id.bAcerca);
            Aviso = FindViewById<ImageView>(Resource.Id.bAviso);
            Modificar = FindViewById<ImageView>(Resource.Id.bModificar);
            CerrarSesion = FindViewById<TextView>(Resource.Id.txtCerrarSesion);
            Acerca.Click += Acerca_Click;
            Aviso.Click += Aviso_Click;
            //bUnirse.Click += bUnirse_Click;
            Modificar.Click += bModificar_Click;
            CerrarSesion.Click += CerrarSesion_Click;

        }

        private void CerrarSesion_Click(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alerDialog = builder.Create();
            //Titulo
            alerDialog.SetTitle("SESIÓN");
            //Icono
            alerDialog.SetIcon(Resource.Drawable.Icon);
            //Pregunta
            alerDialog.SetMessage("¿Estás Seguro?");
            alerDialog.SetButton("NO", (s, ev) =>
            {
                StartActivity(typeof(Configuracion));
            });
            alerDialog.SetButton3("Si", (s, ev) =>
            {
                appCode.ChangeLoginStatus(this, 0);
                appCode.SaveUser(this, 0);
                StartActivity(typeof(MainActivity));

            });
            alerDialog.Show();

        }

        private void bModificar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ModificarPerfil));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        //private void bUnirse_Click(object sender, EventArgs e)
        //{
        //    Android.App.AlertDialog.Builder build = new AlertDialog.Builder(this);
        //    AlertDialog alertDialog = build.Create();
        //    alertDialog.SetTitle("Mensaje");
        //    alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
        //    alertDialog.SetMessage("Login Exitoso !");
        //    alertDialog.SetButton("OK", (s, ev) =>
        //    {
        //        StartActivity(typeof(MenuPrincipal));
        //    });
        //    alertDialog.Show();
        //}

        private void Aviso_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AvisoDePrivacidad));
        }

        private void Acerca_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AcercaDe));
        }



    }
}