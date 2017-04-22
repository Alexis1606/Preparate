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
    [Activity(Label = "Select_Registro")]
    public class Select_Registro : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

              SetContentView(Resource.Layout.Select_Registro);
            // Create your application here
            ImageButton registro = FindViewById<ImageButton>(Resource.Id.BotonRegistro);
            TextView Acceder = FindViewById<TextView>(Resource.Id.txtAcceder);
            
            Acceder.Click += delegate {
               StartActivity(typeof(Acceder));

            };

            registro.Click += delegate {
                StartActivity(typeof(Crear_Perfil));

            };
          
        }
    }
}