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
    [Activity(Label = "Quiz")]
    public class Quiz : Activity
    {
        Button bEnviar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Quiz);

            bEnviar = FindViewById<Button>(Resource.Id.bEnviar);

            bEnviar.Click += Aceptar_Click;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Resultado));
        }
    }
}