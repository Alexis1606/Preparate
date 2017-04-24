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
using Android.Graphics;
using Android.Provider;

namespace preparate
{
    [Activity(Label = "MenuPrincipal", Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MenuPrincipal : AppCompatActivity
    {


        Button test;
        //CAMARA
        ImageView perfil;
        int count = 1;

        //

        GridView gridView;
        string[] gridViewString = {
            "Quiz","Examen","LeaderBoard","Configuración"
             //"Location","Sound","Note","List",
              //"Location","Sound","Note","List"
        };
        int[] imageId = {
            Resource.Drawable.Quiz,Resource.Drawable.Examen,Resource.Drawable.leaderBoard,Resource.Drawable.Ajustes
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

            test = FindViewById<Button>(Resource.Id.test);
            test.Click += test_click;

            perfil = FindViewById<ImageView>(Resource.Id.IconoPerfil);

            perfil.Click += perfil_Click;




            CustomGridViewAdapter adapter = new CustomGridViewAdapter(this, gridViewString, imageId);
            gridView = FindViewById<GridView>(Resource.Id.grid_view_image_text);
            gridView.Adapter = adapter;
            gridView.ItemClick += OnListItemClick;
            //gridView.ItemClick += (s, e) => {
            //    Toast.MakeText(this, "GridView Item: " + gridViewString[e.Position], ToastLength.Short).Show();
            //};
        }

        private void test_click(object sender, EventArgs e)
        {
            StartActivity(typeof(Test));
        }


        //CAMARA
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            perfil.SetImageBitmap(bitmap);
        }
        //
        private void perfil_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(VerPerfil));
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var l = gridViewString[e.Position];
            if (l == "Quiz")
            {
                StartActivity(typeof(Lista_De_Examenes));
            }
            else
            if (l == "Examen")
            {
                StartActivity(typeof(ListaExamenesCompletos));
            }
            else
                if (l == "LeaderBoard")
            {
                StartActivity(typeof(leaderboard));
            }
            else
                if (l == "Configuración")
            {
                StartActivity(typeof(Configuracion));
            }

        }
    }
}