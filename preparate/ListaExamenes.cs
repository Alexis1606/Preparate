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
    [Activity(Label = "Quiz", NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]


    public class Lista_De_Examenes : Activity
    {
        List<cls_ListView> Quiz = new List<cls_ListView>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ListaExamenes);

            //Quiz.Add(new cls_ListView(1, "CENEVAL", "PREPARACIÓN"));
            //Quiz.Add(new cls_ListView(2, "EXIL", "PREPARACIÓN"));
            //Quiz.Add(new cls_ListView(3, "UNAM", "INGRESO"));
            //Quiz.Add(new cls_ListView(4, "IPN", "INGRESO"));
            //Quiz.Add(new cls_ListView(5, "UAM", "INGRESO"));
            Quiz.Add(new cls_ListView(6, "CCNA", "CERTIFICACIÓN"));
            Quiz.Add(new cls_ListView(7, "ORACLE", "CERTIFICACIÓN"));
            //Quiz.Add(new cls_ListView(8, "PENDIENTE 8", "PENDIENTE 8"));

            ListView lwExamenes = FindViewById<ListView>(Resource.Id.lwExamenes);

            lwExamenes.Adapter = new adapter_listview(this, Quiz);

            lwExamenes.ItemClick += OnListItemClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            StartActivity(typeof(MenuPrincipal));
            return base.OnOptionsItemSelected(item);
        }

        protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var l = Quiz[e.Position];
            Android.Widget.Toast.MakeText(this, l.tipodeExamen, Android.Widget.ToastLength.Short).Show();
            
            if (l.tipodeExamen == "CENEVAL")
            {
                //StartActivity(typeof(Quiz));
            }
            if (l.tipodeExamen == "EXIL")
            {
            //    StartActivity(typeof(Quiz));
            }
            if (l.tipodeExamen == "UNAM")
            {
              //  StartActivity(typeof(Quiz));
            }
                        
            if (l.tipodeExamen == "IPN")
            {
                //StartActivity(typeof(Quiz));
            }
            if (l.tipodeExamen == "UAM")
            {
                //StartActivity(typeof(Quiz));
            }
            if (l.tipodeExamen == "CCNA")
            {
                try
                {
                StartActivity(typeof(Quiz));
                }catch(Exception ex)
                {

                }
            }

            if (l.tipodeExamen == "ORACLE")
            {
                try { 
                StartActivity(typeof(Oracle));
                }
                catch (Exception ex)
                {

                }
            }
        }
        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(MenuPrincipal));
            StartActivity(intent);
            //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
        }

    }
}