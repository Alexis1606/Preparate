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
using Android.Bluetooth;
using static Android.Bluetooth.BluetoothClass;
using Android.Content.PM;

namespace preparate
{
    [Activity(Label = "Acerca De Prepárate", ScreenOrientation = ScreenOrientation.Portrait)]
    public class AcercaDe : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AcercaDe);
            // Create your application here
            Button button = FindViewById<Button>(Resource.Id.ok);
            button.Click += delegate {
                try
                {

                
                var uri = Android.Net.Uri.Parse("tel:(55)44533405");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
                }catch(Exception ex) { 
}
            };

            Button emailButton = FindViewById<Button>(Resource.Id.correo);
            emailButton.Click += delegate
            {
                var email = new Intent(Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] {
            "susairajs@preparate.com",
            "susairajs18@preparate.com"
        });
                email.PutExtra(Android.Content.Intent.ExtraCc, new string[] {
            "susairajs18@preparate.com"
        });
                email.PutExtra(Android.Content.Intent.ExtraSubject, "Comentario");
                email.PutExtra(Android.Content.Intent.ExtraText, "Danos tu comentario");
                email.SetType("message/rfc822");
                StartActivity(email);
            };


        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.regresar, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            StartActivity(typeof(Configuracion));
            Finish();
            return base.OnOptionsItemSelected(item);
            
        }

        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(Configuracion));
            StartActivity(intent);
            Finish();
            //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
        }

        

        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    switch (item.ItemId)
        //    {
        //        case Resource.Id.menu:
        //            var aboutPage = new Intent(this, typeof(MenuPrincipal));
        //            StartActivity(aboutPage);
        //            return true;
        //        case Resource.Id.perfil:
        //            var missionVisionPage = new Intent(this, typeof(VerPerfil));
        //            StartActivity(missionVisionPage);
        //            return true;
        //            //case Resource.Id.mediaConcept:
        //            //    var mediaConceptPage = new Intent(this, typeof(MediaConceptActivity));
        //            //    StartActivity(mediaConceptPage);
        //            //    return true;
        //    }
        //    return base.OnOptionsItemSelected(item);
        //}
    }
}