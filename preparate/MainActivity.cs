//Funciona!!!
using Android.App;
using Android.Widget;
using Android.OS;
using Java.Lang;
using Classes;
using System.IO;
using Android.Content;
using Android.Preferences;
using Android.Net;
using Java.IO;
using API0;

namespace preparate
{
    [Activity(Label = "preparate", MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        ISharedPreferences prefs;
        int user = 0;

        public bool IsConnected
        {
            get
            {
                ConnectivityManager connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
                NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
                return (activeConnection != null) && activeConnection.IsConnected;
            }
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Display Splash Screen for 4 Sec
            Thread.Sleep(2000);

            //prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            //int user = prefs.GetInt("user", 0);
            //API0.InicioSesion.InsertInicioSesion(user);


            //ISharedPreferences prefs1 = PreferenceManager.GetDefaultSharedPreferences(this);
            //int user = prefs1.GetInt("user", 0);
            //User Datos = new User(user);

            //API0.InicioSesion.InsertInicioSesion(user);



            // quitar esta linea cuando ya se tenga el login
            //appCode.ChangeLoginStatus(this, 0);


            try
            {
                bool connect = IsConnected;

                if (connect == false)
                {
                    Toast.MakeText(this, "Por favor, Asegurate de estar conectado a internet y vuelve a intentarlo.", ToastLength.Long).Show();
                    StartActivity(new Android.Content.Intent(Android.Provider.Settings.ActionSettings));
                }
                else{
                    prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                    int Logged_status = prefs.GetInt("Logged_in", 0);
                    user = prefs.GetInt("user", 0);

                    if (user != 0)
                    {
                        API0.InicioSesion.InsertInicioSesion(user);
                    }
                    
                    if (Logged_status == 0)
                    {
                        
                        goToLogin();

                    }
                    else
                    {
                        //prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                        //user = prefs.GetInt("user", 0);
                        //API0.InicioSesion.InsertInicioSesion(user);
                        StartActivity(typeof(MenuPrincipal));
                    }
                }


               
            }
            catch (Exception ex)
            {
                appCode.ChangeLoginStatus(this, 0);
                goToLogin();
                
            }
        }

        private void goToLogin()
        {
            //aqui va el c[odigo para llevar a la  poantalla de login
            StartActivity(typeof(Select_Registro));
        }

    }
}

