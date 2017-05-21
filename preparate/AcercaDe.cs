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

namespace preparate
{
    [Activity(Label = "Acerca De Prep�rate", NoHistory = true)]
    public class AcercaDe : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AcercaDe);
            // Create your application here
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