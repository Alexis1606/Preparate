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
using Android.Preferences;
using System.IO;

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




            try
            {
                ISharedPreferences preferencess = PreferenceManager.GetDefaultSharedPreferences(this);
                string path = preferencess.GetString("Profile_picture", "");

                Android.Net.Uri uri = Android.Net.Uri.FromFile(new Java.IO.File(path));

                System.IO.Stream input = this.ContentResolver.OpenInputStream(uri);
                Byte[] pictByteArray;
                //Use bitarray to use less memory                    
                byte[] buffer = new byte[16 * 1024];
                using (MemoryStream ms = new MemoryStream())
                {
                    int read;
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    pictByteArray = ms.ToArray();
                }

                input.Close();

                //Get file information
                BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
                Bitmap bitmap = BitmapFactory.DecodeByteArray(pictByteArray, 0, pictByteArray.Length);
                perfil.SetImageBitmap(bitmap);



            }
            catch (Exception ex)
            {

            }

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