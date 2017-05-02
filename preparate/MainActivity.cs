﻿using Android.App;
using Android.Widget;
using Android.OS;
using Java.Lang;
using Classes;
using System.IO;
using Android.Content;
using Android.Preferences;
using Android.Net;
using Java.IO;

namespace preparate
{
    [Activity(Label = "preparate", MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
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
           

            // quitar esta linea cuando ya se tenga el login
            //appCode.ChangeLoginStatus(this, 0);


            try
            {
                bool connect = IsConnected;

                if (connect == false)
                {
                    Toast.MakeText(this, "Por favor, segurese de estar conectado a internet y vuelva a intentarlo.", ToastLength.Long).Show();
                 
                }


                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                int Logged_status = prefs.GetInt("Logged_in", 0);
                if (Logged_status == 0)
                {
                    goToLogin();
                }else
                {
                    StartActivity(typeof(MenuPrincipal));
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

