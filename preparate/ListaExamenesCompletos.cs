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
    [Activity(Label = "Examen Completo")]


    public class ListaExamenesCompletos : Activity
    {
        List<cls_ListView> ExamenesCompletos = new List<cls_ListView>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ListaExamenesCompletos);

            ExamenesCompletos.Add(new cls_ListView(1, "PREPARACIÓN", "CENEVAL"));
            ExamenesCompletos.Add(new cls_ListView(2, "PREPARACIÓN", "EXIL"));
            ExamenesCompletos.Add(new cls_ListView(3, "INGRESO", "UNAM"));
            ExamenesCompletos.Add(new cls_ListView(4, "INGRESO", "IPN"));
            ExamenesCompletos.Add(new cls_ListView(5, "INGRESO", "UAM"));
            ExamenesCompletos.Add(new cls_ListView(6, "CERTIFICACIÓN", "CCNA"));
            ExamenesCompletos.Add(new cls_ListView(7, "CERTIFICACIÓN", "ORACLE"));
            ExamenesCompletos.Add(new cls_ListView(8, "PENDIENTE 8", "PENDIENTE 8"));

            ListView lwExamenes = FindViewById<ListView>(Resource.Id.lwExamenes);

            lwExamenes.Adapter = new adapter_listview(this, ExamenesCompletos);

            lwExamenes.ItemClick += OnListItemClick;
        }

        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var l = ExamenesCompletos[e.Position];
            Android.Widget.Toast.MakeText(this, l.tipodeExamen, Android.Widget.ToastLength.Short).Show();
            if (l.tipodeExamen == "PREPARACIÓN")
            {
                StartActivity(typeof(ExamenesCompletos));
            }
            if (l.tipodeExamen == "INGRESO")
            {
                StartActivity(typeof(ExamenesCompletos));
            }
            if (l.tipodeExamen == "CERTIFICACIÓN")
            {
                StartActivity(typeof(ExamenesCompletos));
            }
        }


    }
}