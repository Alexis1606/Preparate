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
    [Activity(Label = "Acceder")]
    public class Acceder : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            EditText Correo;
            EditText Contrasena;
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Acceder);
            Contrasena = FindViewById<EditText>(Resource.Id.txtPassword);

            // Create your application here

            API0.User.login(mail, password);
        }
    }
}