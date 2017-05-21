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
    [Activity(Label = "Nuestro Aviso De Privacidad", NoHistory = true)]
    public class AvisoDePrivacidad : Activity
    {
        Button bAceptar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AvisoDePrivacidad);
            bAceptar = FindViewById<Button>(Resource.Id.bAceptar);
            bAceptar.Click += Aceptar_Click;
            // Create your application here
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.regresar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            StartActivity(typeof(Configuracion));
            return base.OnOptionsItemSelected(item);
            Finish();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MenuPrincipal));
            Finish();
        }
        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(Configuracion));
            StartActivity(intent);
            //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
        }
    }
}