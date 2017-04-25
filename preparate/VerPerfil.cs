using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Provider;
using Android.Preferences;
using API0;
using Java.IO;
using System.IO;

namespace preparate
{
    [Activity(Label = "Perfil")]
    public class VerPerfil : Activity
    {
        ImageView perfil;
        TextView Nombre;
        TextView Puntaje;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.VerPerfil);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            int user = prefs.GetInt("user", 0);
            User Datos = new User(user);


            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SlidingTabsFragment fragment = new SlidingTabsFragment();
            transaction.Replace(Resource.Id.sample_content_fragment, fragment);
            transaction.Commit();
            perfil = FindViewById<ImageView>(Resource.Id.fotoPerfil);
            Nombre = FindViewById<TextView>(Resource.Id.txtNombrePerfil);
            Puntaje = FindViewById<TextView>(Resource.Id.txtPuntajePerfil);
            perfil.Click += perfil_Click;

            Nombre.Text = Datos.Nombre.ToUpper();

            try
            {
                ISharedPreferences preferencess = PreferenceManager.GetDefaultSharedPreferences(this);
                string path = preferencess.GetString("Profile_picture","");

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
        //ver foto
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            perfil.SetImageBitmap(bitmap);
            
            ContextWrapper cw = new ContextWrapper(this.ApplicationContext);

            var fileName = cw.GetDir("imgDir", FileCreationMode.Private).ToString() + "/profile.png";
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("Profile_picture", fileName.ToString());
            editor.Apply();

            try
            {
                var os1 = new FileStream(fileName, FileMode.Truncate);
                os1.Close();
            }
            catch (Exception ex)
            {
                int x = 0;
            }
            using (var os = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 95, os);
                os.Close();
            }
            
        } 

        //Opciones ...
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        //Al dar click en la foto
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