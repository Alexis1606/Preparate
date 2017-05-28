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
using Android.Content.PM;

namespace preparate
{
    [Activity(Label = "Examen Completo", ScreenOrientation = ScreenOrientation.Portrait)]


    public class ListaExamenesCompletos : Activity
    {
        List<cls_ListView> ExamenesCompletos = new List<cls_ListView>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ListaExamenesCompletos);

            ExamenesCompletos.Add(new cls_ListView(1, "CENEVAL", "PREPARACIÓN"));
            ExamenesCompletos.Add(new cls_ListView(2, "EXIL", "PREPARACIÓN"));
            ExamenesCompletos.Add(new cls_ListView(3, "UNAM", "INGRESO"));
            ExamenesCompletos.Add(new cls_ListView(4, "IPN", "INGRESO"));
            ExamenesCompletos.Add(new cls_ListView(5, "UAM", "INGRESO"));
            ExamenesCompletos.Add(new cls_ListView(6, "CCNA", "CERTIFICACIÓN"));
            ExamenesCompletos.Add(new cls_ListView(7, "ORACLE", "CERTIFICACIÓN"));
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
            
            if (l.tipodeExamen == "CENEVAL")
            {
                StartActivity(typeof(ExamenesCompletos));
            }
            if (l.tipodeExamen == "EXIL")
            {
                StartActivity(typeof(ExamenesCompletos));
            }
            if (l.tipodeExamen == "UNAM")
            {
                StartActivity(typeof(ExamenesCompletos));
            }

            if (l.tipodeExamen == "IPN")
            {
                StartActivity(typeof(ExamenesCompletos));
            }
            if (l.tipodeExamen == "UAM")
            {
                StartActivity(typeof(ExamenesCompletos));
            }
            if (l.tipodeExamen == "CCNA")
            {
                StartActivity(typeof(ExamenesCompletos));
            }

            if (l.tipodeExamen == "ORACLE")
            {
                StartActivity(typeof(ExamenesCompletos));
            }
        }


    }
}