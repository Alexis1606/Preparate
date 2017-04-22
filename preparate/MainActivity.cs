using Android.App;
using Android.Widget;
using Android.OS;
using Java.Lang;

namespace preparate
{
    [Activity(Label = "preparate", MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true, Icon = "@drawable/Icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Display Splash Screen for 4 Sec
            Thread.Sleep(2000);
            //Start Activity1 Activity
            //StartActivity(typeof(Crear_Perfil));
            StartActivity(typeof(Select_Registro));
        }
    }
}

