using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Provider;

namespace preparate
{
    [Activity(Label = "Perfil")]
    public class VerPerfil : Activity
    {
         ImageView perfil;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.VerPerfil);

            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment();
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();

            perfil = FindViewById<ImageView>(Resource.Id.fotoPerfil);

            perfil.Click += perfil_Click;

        }
        //ver foto
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            perfil.SetImageBitmap(bitmap);
        }
        //SLIDING TAB
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        private void perfil_Click(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alerDialog = builder.Create();
            //Titulo
            alerDialog.SetTitle("PERFIL");
            //Icono
            alerDialog.SetIcon(Resource.Drawable.Perfil);
            //Pregunta
            alerDialog.SetMessage("¿Desea cambiar la foto de Perfil?");
            alerDialog.SetButton("No", (s, ev) =>
            {
                StartActivity(typeof(VerPerfil));
            });
            alerDialog.SetButton3("Si", (s, ev) =>
            {

                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
                //StartActivity(typeof(MenuPrincipal));
            });
            alerDialog.Show();
        }
    }
}