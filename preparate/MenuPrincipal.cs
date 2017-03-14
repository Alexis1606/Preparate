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
using Android.Support.V7.App;

namespace preparate
{
    [Activity(Label = "MenuPrincipal", Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MenuPrincipal : AppCompatActivity
    {
         GridView gridView;
        string[] gridViewString = {
            "Quiz","Examen","Ajustes","Acerca de"
             //"Location","Sound","Note","List",
              //"Location","Sound","Note","List"
        };
        int[] imageId = {
            Resource.Drawable.Quiz,Resource.Drawable.Examen,Resource.Drawable.Ajustes,Resource.Drawable.Acerca
             //Resource.Drawable.location,Resource.Drawable.sound,Resource.Drawable.note,Resource.Drawable.list,
              //Resource.Drawable.location,Resource.Drawable.sound,Resource.Drawable.note,Resource.Drawable.list
        };
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MenuPrincipal);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "Menú Principal";
            SupportActionBar.SetLogo(Resource.Drawable.Home);

            CustomGridViewAdapter adapter = new CustomGridViewAdapter(this, gridViewString, imageId);
            gridView = FindViewById<GridView>(Resource.Id.grid_view_image_text);
            gridView.Adapter = adapter;
            gridView.ItemClick += OnListItemClick;
            //gridView.ItemClick += (s, e) => {
            //    Toast.MakeText(this, "GridView Item: " + gridViewString[e.Position], ToastLength.Short).Show();
            //};
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var l = gridViewString[e.Position];
            //Android.Widget.Toast.MakeText(this, l, Android.Widget.ToastLength.Short).Show();
            if (l == "Quiz")
            {
                //StartActivity(typeof());
            }
            else
            if (l == "Examen")
            {
                //StartActivity(typeof());
            }
            else
                if (l == "Ajustes")
            {
                //StartActivity(typeof());
            }
            else
                if (l == "Acerca de")
            {
                StartActivity(typeof(AcercaDe));
            }

            else
                if (l == "Acerca de")
            {
                //StartActivity(typeof());
            }

        }
    }
}