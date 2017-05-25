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
using Android.Util;
using API0;
using Android.Preferences;

namespace preparate
{
    [Activity(Label = "Modificar Datos", Icon = "@drawable/Icon", NoHistory = true)]
    public class ModificarPerfil : Activity
    {
        EditText txtNombre;
        EditText txtApellidos;
        EditText txtEmail;
        Button txtFechaNac;
        TextView textoGenero;
        RadioButton GeneroMasculino;
        RadioButton GeneroFemenino;        
        Button bValidar;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ModificarPerfil);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            int user = prefs.GetInt("user", 0);
            User Datos = new User(user);
            

            txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            txtApellidos = FindViewById<EditText>(Resource.Id.txtApellidos);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtFechaNac = FindViewById<Button>(Resource.Id.txtFechaNac);
            txtFechaNac.Click += txtFecha_Click;
            textoGenero = FindViewById<TextView>(Resource.Id.textoGenero);
            GeneroMasculino = FindViewById<RadioButton>(Resource.Id.GeneroMasculino);
            GeneroFemenino = FindViewById<RadioButton>(Resource.Id.GeneroFemenino);
            bValidar = FindViewById<Button>(Resource.Id.ok);
            bValidar.Click += BValidar_Click;

            txtNombre.Text = Datos.Nombre;
            txtApellidos.Text = Datos.Apellido_Parterno;
            txtEmail.Text = Datos.Correo;
            txtFechaNac.Text = Datos.Fecha_Nacimiento;

            if (Datos.Genero ==0)
            {
                GeneroMasculino.Checked = false;
                GeneroFemenino.Checked = true;
            }
            else
            {
                GeneroMasculino.Checked = true;
                GeneroFemenino.Checked = false;
                
            }            

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

        private void txtFecha_Click(object sender, EventArgs e)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                txtFechaNac.Text = time.ToLongDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void BValidar_Click(object sender, EventArgs e)
        {
            try
            {

            
            //obtener_datos();
            int genero;

            if (validar_EditText(txtNombre) && validar_EditText(txtApellidos) && validar_EditText(txtEmail) && txtFechaNac.Text != "" && validarMail(txtEmail))
            {
                if (GeneroMasculino.Checked)
                {
                    genero = 1;
                }
                else
                {
                    genero = 0;
                }

                try
                {
                    //API0.User.InsertUser(txtNombre.Text, txtApellidos.Text, "", Convert.ToDateTime(txtFechaNac.Text), tContra1.Text, txtEmail.Text, genero, 1, 1, "a");

                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                    int user = prefs.GetInt("user", 0);
                    
                    API0.User.UpdatetUser(user,txtNombre.Text, txtApellidos.Text, Convert.ToDateTime(txtFechaNac.Text), txtEmail.Text, genero);
                    Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
                    AlertDialog alertDialog = builder.Create();
                    alertDialog.SetTitle("ACTUALIZACIÓN");
                    alertDialog.SetIcon(Resource.Drawable.Icon);
                    alertDialog.SetMessage("Actualización Correcta");
                    alertDialog.SetButton("OK", (s, ev) =>
                    {
                        StartActivity(typeof(MenuPrincipal));
                        Finish();
                    });
                    alertDialog.Show();


                }

                catch (Exception ex)
                {
                    string x = ex.ToString();
                    int x1 = 0;
                }
            }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Parece que hubo un error al intentar modificar los datos. Inténtalo de nuevo.", ToastLength.Long).Show();
            }
        }

        private bool validarMail(EditText txtEmail)
        {
            if(txtEmail.Text.Contains("@")&&(txtEmail.Text.Contains(".com") || txtEmail.Text.Contains(".edu") || txtEmail.Text.Contains(".gob") || txtEmail.Text.Contains(".mx")))
            {
                return true;
            }else
            {
                Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
                AlertDialog alertDialog = builder.Create();
                alertDialog.SetTitle("Correo inválido");
                alertDialog.SetIcon(Resource.Drawable.Icon);
                alertDialog.SetMessage("Correo con formato inválido." + System.Environment.NewLine + "Ingresa un correo con el formato" + System.Environment.NewLine + "example@example.com" + System.Environment.NewLine);
                alertDialog.SetButton("OK", (s, ev) =>
                {
                });
                alertDialog.Show();                
                return false;
            }
        }

        public bool validar_EditText(EditText t)
        {
            bool v = false;
            if (t.Text == "" || t.Text == null)
            {
                t.SetBackgroundColor(Android.Graphics.Color.Orange);
                Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
                AlertDialog alertDialog = builder.Create();
                alertDialog.SetTitle("REGISTRO");
                alertDialog.SetMessage("Te faltan algunos campos !");
                alertDialog.SetButton("OK", (s, ev) =>
                {
                });
                alertDialog.Show();
            }

            else
            {
                v = true;
            }
            return v;
        }

        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(Configuracion));
            StartActivity(intent);
            //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
        }
    }


    //public class DatePickerFragment : DialogFragment, DatePickerDialog.IOnDateSetListener
    //{
    //    // TAG can be any string of your choice.
    //    public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();

    //    // Initialize this value to prevent NullReferenceExceptions.
    //    Action<DateTime> _dateSelectedHandler = delegate { };

    //    public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
    //    {
    //        DatePickerFragment frag = new DatePickerFragment();
    //        frag._dateSelectedHandler = onDateSelected;
    //        return frag;
    //    }

    //    public override Dialog OnCreateDialog(Bundle savedInstanceState)
    //    {
    //        DateTime currently = DateTime.Now;
    //        DatePickerDialog dialog = new DatePickerDialog(Activity,
    //                                                       this,
    //                                                       currently.Year,
    //                                                       currently.Month,
    //                                                       currently.Day);
    //        return dialog;
    //    }

    //    public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
    //    {
    //        // Note: monthOfYear is a value between 0 and 11, not 1 and 12!
    //        DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
    //        Log.Debug(TAG, selectedDate.ToLongDateString());
    //        _dateSelectedHandler(selectedDate);

    //    }


    //}
   

}