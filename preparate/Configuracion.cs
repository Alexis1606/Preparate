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
    [Activity(Label = "Configuración", NoHistory = false)]
    public class Configuracion : Activity
    {
        ImageView Modificar;
        ImageView Acerca;
        ImageView Aviso;
        ImageView FeedBack;
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
            FeedBack = FindViewById<ImageView>(Resource.Id.bFeedBack);
            CerrarSesion = FindViewById<TextView>(Resource.Id.txtCerrarSesion);            
            Acerca.Click += Acerca_Click;
            Aviso.Click += Aviso_Click;
            //bUnirse.Click += bUnirse_Click;
            Modificar.Click += bModificar_Click;
            CerrarSesion.Click += CerrarSesion_Click;
            FeedBack.Click += FeedBack_Click;

        }

        private void FeedBack_Click(object sender, EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://docs.google.com/forms/d/e/1FAIpQLSe_BMvCLkessoOfpOSJsg1bcb49K3U_oj3OQH8r2yYMZX0tRA/viewform?usp=sf_link");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
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
            alerDialog.SetMessage("¿Estás seguro que deseas cerrar la sesión?");
            alerDialog.SetButton("No", (s, ev) =>
            {
                StartActivity(typeof(Configuracion));
                Finish();
            });
            alerDialog.SetButton3("Si", (s, ev) =>
            {
                appCode.ChangeLoginStatus(this, 0);
                appCode.SaveUser(this, 0);
                StartActivity(typeof(MainActivity));
                Finish();

            });
            alerDialog.Show();

        }

        private void bModificar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ModificarPerfil));
            Finish();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            StartActivity(typeof(MenuPrincipal));
            Finish();
            return base.OnOptionsItemSelected(item);
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
            Finish();
        }

        private void Acerca_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AcercaDe));
            Finish();
        }

        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(MenuPrincipal));
            StartActivity(intent);
            Finish();
            //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
        }

    }
}