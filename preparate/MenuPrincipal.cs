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
        //CAMARA
        ImageView perfil;
        int count = 1;
        
        //

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

           

            perfil = FindViewById<ImageView>(Resource.Id.imageView1);

            perfil.Click +=  perfil_Click;


            CustomGridViewAdapter adapter = new CustomGridViewAdapter(this, gridViewString, imageId);
            gridView = FindViewById<GridView>(Resource.Id.grid_view_image_text);
            gridView.Adapter = adapter;
            gridView.ItemClick += OnListItemClick;
            //gridView.ItemClick += (s, e) => {
            //    Toast.MakeText(this, "GridView Item: " + gridViewString[e.Position], ToastLength.Short).Show();
            //};
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

            //Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            //Android.App.AlertDialog alerDialog = builder.Create();
            ////Titulo
            //alerDialog.SetTitle("PERFIL");
            ////Icono
            //alerDialog.SetIcon(Resource.Drawable.Perfil);
            ////Pregunta
            //alerDialog.SetMessage("Elige Una opción");
            //alerDialog.SetButton("Ver Perfil", (s, ev) =>
            //{ 
            //    StartActivity(typeof(VerPerfil));
            //});
            //alerDialog.SetButton3("Cambiar Foto", (s, ev) =>
            //{
                
            //    Intent intent = new Intent(MediaStore.ActionImageCapture);
            //    StartActivityForResult(intent, 0);
            //    //StartActivity(typeof(MenuPrincipal));
            //});
            //alerDialog.Show();

        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var l = gridViewString[e.Position];
            //Android.Widget.Toast.MakeText(this, l, Android.Widget.ToastLength.Short).Show();
            if (l == "Quiz")
            {
                StartActivity(typeof(Quiz));
            }
            else
            if (l == "Examen")
            {
                //StartActivity(typeof());
            }
            else
                if (l == "Ajustes")
            {
                StartActivity(typeof(Configuracion));
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