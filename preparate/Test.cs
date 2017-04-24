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
using Android.Graphics;

using Classes;

namespace preparate
{
    [Activity(Label = "Test")]
    public class Test : Activity
    {
        Spinner s1;
        Spinner s2;
        API0.TipoExamen[] te;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.Test);

            s1 = FindViewById<Spinner>(Resource.Id.spinner1);
            s2 = FindViewById<Spinner>(Resource.Id.spinner2);
            te = API0.TipoExamen.all();
            var items = new List<string>()
            { };
            foreach (API0.TipoExamen t in te)
            {
                items.Add(t.desc);
            }
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
            s1.Adapter = adapter;
            s1.ItemSelected += spinner1_ItemSelected;


        }

        private void spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            //Spinner spinner = (Spinner)sender;

            //string toast = string.Format("El tipo de examen es {0}", spinner.GetItemAtPosition(e.Position));
            //Toast.MakeText(this, toast, ToastLength.Long).Show();
            int tipo = te[e.Position].id;
            API0.Certificadores[] cert = API0.Certificadores.all();
            API0.Materia[] mat = API0.Materia.all();
            var items = new List<string>()
            { };
            switch (tipo)
            {
                case 0:
                    items.Add("-");
                    s2.Enabled = false;
                    break;
                case 5:
                    foreach (API0.Certificadores t in cert)
                    {
                        items.Add(t.desc);
                    }

                    s2.Enabled = true;
                    break;
                case 6:
                    foreach (API0.Materia t in mat)
                    {
                        items.Add(t.desc);
                    }
                    s2.Enabled = true;
                    break;
            }
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
            s2.Adapter = adapter;
            s2.ItemSelected += spinner2_ItemSelected;




        }
        private void spinner2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {


        }


    }
}