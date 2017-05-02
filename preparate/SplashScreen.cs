//comentario para subir cambio
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
using Java.Lang;
using Android.Net;
using Android.Util;

namespace preparate
{
    //Set MainLauncher = true makes this Activity Shown First on Running this Application
    //Theme property set the Custom Theme for this Activity
    //No History= true removes the Activity from BackStack when user navigates away from the Activity
    //  [Activity(Label = "Splash Screen App", Theme = "@style/Theme.Splash", NoHistory = true)]

    public class SplashScreen : Activity
    {
        static readonly string TAG = typeof(SplashScreen).FullName;

        protected override void OnCreate(Bundle bundle)
        {
                base.OnCreate(bundle);
            //    //Display Splash Screen for 4 Sec
            //    Thread.Sleep(4000);
            ////Start Activity1 Activity
            //StartActivity(typeof(Crear_Perfil));

            DetectNetwork();
            DetectNetworks();
            DetectNetworkT();

            //--------------------------------------------

            //ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

            //NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
            //bool isOnline = networkInfo.IsConnected;
            //bool isWifi = networkInfo.Type == ConnectivityType.Wifi;
            //if (isWifi)
            //{
            //    Android.App.AlertDialog.Builder build = new AlertDialog.Builder(this);
            //    AlertDialog alertDialog = build.Create();
            //    alertDialog.SetTitle("Mensaje");
            //    alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            //    alertDialog.SetMessage("Parece que estas conectado a wifi");
            //    alertDialog.SetButton("OK", (s, ev) =>
            //    {
            //        StartActivity(typeof(SplashScreen));
            //    });
            //    alertDialog.Show();
            //}
            //else
            //{
            //    Android.App.AlertDialog.Builder build = new AlertDialog.Builder(this);
            //    AlertDialog alertDialog = build.Create();
            //    alertDialog.SetTitle("Mensaje");
            //    alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            //    alertDialog.SetMessage("Parece que no estas conectado a wifi");
            //    alertDialog.SetButton("OK", (s, ev) =>
            //    {
            //        StartActivity(typeof(SplashScreen));
            //    });
            //    alertDialog.Show();
            //}

            //---------------------------


        }


        protected override void OnResume()
        {
            base.OnResume();
            DetectNetworkT();
        }


        private void DetectNetwork()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(Context.ConnectivityService);
            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            bool isOnline = (activeConnection != null) && activeConnection.IsConnected;
            if (!isOnline)
                Toast.MakeText(this, "Por favor, segurese de estar conectado a internet y vuelva a intentarlo.", ToastLength.Long).Show();
        }

        private void DetectNetworks()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);

            NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
            bool isOnline = networkInfo.IsConnected;
            bool isWifi = networkInfo.Type == ConnectivityType.Wifi;
            if (isWifi)
            {
                Android.App.AlertDialog.Builder build = new AlertDialog.Builder(this);
                AlertDialog alertDialog = build.Create();
                alertDialog.SetTitle("Mensaje");
                alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                alertDialog.SetMessage("Parece que estas conectado a wifi");
                alertDialog.SetButton("OK", (s, ev) =>
                {
                    StartActivity(typeof(SplashScreen));
                });
                alertDialog.Show();
            }
            else
            {
                Android.App.AlertDialog.Builder build = new AlertDialog.Builder(this);
                AlertDialog alertDialog = build.Create();
                alertDialog.SetTitle("Mensaje");
                alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                alertDialog.SetMessage("Parece que no estas conectado a wifi");
                alertDialog.SetButton("OK", (s, ev) =>
                {
                    StartActivity(typeof(SplashScreen));
                });
                alertDialog.Show();
            }
        }


        private void DetectNetworkT()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            NetworkInfo info = connectivityManager.ActiveNetworkInfo;
            bool isOnline = info.IsConnected;

            Log.Debug(TAG, "IsOnline = {0}", isOnline);

            if (isOnline)
            {
               

                // Display the type of connectionn
                NetworkInfo.State activeState = info.GetState();


                // Check for a WiFi connection
                bool isWifi = info.Type == ConnectivityType.Wifi;
                if (isWifi)
                {
                    Android.App.AlertDialog.Builder build = new AlertDialog.Builder(this);
                    AlertDialog alertDialog = build.Create();
                    alertDialog.SetTitle("Mensaje");
                    alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                    alertDialog.SetMessage("Parece que estas conectado a wifi");
                    alertDialog.SetButton("OK", (s, ev) =>
                    {
                        StartActivity(typeof(SplashScreen));
                    });
                    alertDialog.Show();

                }
                else
                {
                    Log.Debug(TAG, "Wifi disconnected.");

                }

                // Check if roaming
                if (info.IsRoaming)
                {
                    Log.Debug(TAG, "Roaming.");

                }
                else
                {
                    Log.Debug(TAG, "Not roaming.");

                }
            }
            else
            {
              
            }
        }

    }
}