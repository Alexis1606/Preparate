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
    [Activity(Label = "Prepárate")]
    public class Select_Registro : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

              SetContentView(Resource.Layout.Select_Registro);
            //Create your application here
            Button registro = FindViewById<Button>(Resource.Id.BotonRegistro);
            Button Acceder = FindViewById<Button>(Resource.Id.BInicioSesion);

            Acceder.Click += delegate {
               StartActivity(typeof(Acceder));

            };

            registro.Click += delegate {
                StartActivity(typeof(Crear_Perfil));

            };
          
        }
    }
}