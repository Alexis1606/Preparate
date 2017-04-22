using Android.Content;
using Android.Preferences;

namespace preparate
{
    public class appCode
    {
        //usage    ChangeLoginStatus(this,0/1)

        public static void ChangeLoginStatus(Context c, int status)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(c);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutInt("Logged_in", status);
            editor.Apply();
        }

        public static void SaveUser(Context c, int user)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(c);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutInt("user", user);
            editor.Apply();
        }

      

    }
}