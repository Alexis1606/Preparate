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


    public class Lista_De_Examenes : Activity
    {
        List<cls_ListView> Quiz = new List<cls_ListView>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ListaExamenes);

            Quiz.Add(new cls_ListView(1, "PREPARACI�N", "CENEVAL"));
            Quiz.Add(new cls_ListView(2, "PREPARACI�N", "EXIL"));
            Quiz.Add(new cls_ListView(3, "INGRESO", "UNAM"));
            Quiz.Add(new cls_ListView(4, "INGRESO", "IPN"));
            Quiz.Add(new cls_ListView(5, "INGRESO", "UAM"));
            Quiz.Add(new cls_ListView(6, "CERTIFICACI�N", "CCNA"));
            Quiz.Add(new cls_ListView(7, "CERTIFICACI�N", "ORACLE"));
            Quiz.Add(new cls_ListView(8, "PENDIENTE 8", "PENDIENTE 8"));

            ListView lwExamenes = FindViewById<ListView>(Resource.Id.lwExamenes);

            lwExamenes.Adapter = new adapter_listview(this, Quiz);

            lwExamenes.ItemClick += OnListItemClick;
        }

        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var l = Quiz[e.Position];
            Android.Widget.Toast.MakeText(this, l.tipodeExamen, Android.Widget.ToastLength.Short).Show();
            if (l.tipodeExamen == "PREPARACI�N")
            {
                StartActivity(typeof(Quiz));
            }
            if (l.tipodeExamen == "INGRESO")
            {
                StartActivity(typeof(Quiz));
            }
            if (l.tipodeExamen == "CERTIFICACI�N")
            {
                StartActivity(typeof(Quiz));
            }
        }


    }
}