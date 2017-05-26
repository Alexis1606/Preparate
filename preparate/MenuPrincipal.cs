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
using System.Threading.Tasks;
using Firebase.Iid;

namespace preparate
{
    [Activity(Label = "MenuPrincipal", Icon = "@drawable/icon", Theme = "@style/MyTheme", NoHistory = false)]
    public class MenuPrincipal : AppCompatActivity
    {
        //Button test;
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
            SetContentView(Resource.Layout.MenuPrincipal);

            //if (!GetString(Resource.String.google_app_id).Equals("1:593192999279:android:7fd609f7126dc407"))
            //    throw new System.Exception("Invalid Json file");
            //Task.Run(() =>
            //{
            //    var instanceId = FirebaseInstanceId.Instance;
            //    instanceId.DeleteInstanceId();
            //    Android.Util.Log.Debug("TAG", "{0} {1}", instanceId.Token, instanceId.GetToken(GetString(Resource.String.gcm_defaultSenderId), Firebase.Messaging.FirebaseMessaging.InstanceIdScope));
            //});


            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Menú Principal";
            SupportActionBar.SetLogo(Resource.Drawable.Home);
            //test = FindViewById<Button>(Resource.Id.test);
            //test.Click += test_click;
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

        //private void test_click(object sender, EventArgs e)
        //{
        //    StartActivity(typeof(Test));
        //}


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
            try
            {            
            StartActivity(typeof(VerPerfil));
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Aún no haz contestado ningún examen", ToastLength.Long).Show();
            }
        }

        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            try
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
                //   StartActivity(typeof(ListaExamenesCompletos));
                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alerDialog = builder.Create();
                alerDialog.SetTitle("Versión Pro");
                //poner imagen de respuesta incorrecta
                alerDialog.SetIcon(Resource.Drawable.Icon);
                alerDialog.SetMessage("Obtén la versión PRO.\nPara poder acceder a cientos de preguntas");
                alerDialog.Show();                
            }
            else
                if (l == "LeaderBoard")
            {
                StartActivity(typeof(LeaderBoard2));
            }
            else
                if (l == "Configuración")
            {
                StartActivity(typeof(Configuracion));
            }
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnBackPressed()
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alerDialog = builder.Create();
            alerDialog.SetTitle("Gracias");
            //poner imagen de respuesta incorrecta
            //alerDialog.SetIcon(Resource.Drawable.Icon);
            alerDialog.SetMessage("Por favor danos tu opinión sobre tu experiencia con la aplicación");
            alerDialog.SetButton("Ir a feedback", (se, eve) =>
            {
                try
                {

                
                var uri = Android.Net.Uri.Parse("https://docs.google.com/forms/d/e/1FAIpQLSe_BMvCLkessoOfpOSJsg1bcb49K3U_oj3OQH8r2yYMZX0tRA/viewform?usp=sf_link");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
                Finish();
                }catch(Exception e)
                {

                }
            });
            alerDialog.SetButton2("Ahora no", (se, eve) =>
            {                
                Finish();
            });
            alerDialog.CancelEvent += OnDialogCancel;
            alerDialog.Show();
            //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
        }

        private void OnDialogCancel(object sender, EventArgs eventArgs)
        {
            Finish();
        }

    }
}