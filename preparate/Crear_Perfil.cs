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

namespace preparate
{
    [Activity(Label = "Crear Perfil", Icon = "@drawable/Icon", NoHistory = true)]
    public class Crear_Perfil : Activity
    {
        EditText txtNombre;
        EditText txtApellidos;
        EditText txtEmail;
        Button txtFechaNac;
        TextView textoGenero;
        RadioButton GeneroMasculino;        
        EditText tContra1;
        EditText tContra2;
        Button bValidar;        
        //String nombre;
        //string apellidos;
        //string usuario;
        string contra1;
        string contra2;
      
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Crear_Perfil);
            txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            txtApellidos = FindViewById<EditText>(Resource.Id.txtApellidos);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtFechaNac = FindViewById<Button>(Resource.Id.txtFechaNac);
            txtFechaNac.Click += txtFecha_Click;


            textoGenero = FindViewById<TextView>(Resource.Id.textoGenero);
            GeneroMasculino = FindViewById<RadioButton>(Resource.Id.GeneroMasculino);            
            bValidar = FindViewById<Button>(Resource.Id.ok);
            
            bValidar.Click += BValidar_Click;
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



                string cadena = Convert.ToString(txtFechaNac.Text);
                string[] separadas;
                separadas = cadena.Split(',');
                string dia = separadas[0];
                string mes = separadas[1];
                string año = separadas[2];
                Android.App.AlertDialog.Builder builder10 = new AlertDialog.Builder(this);
                AlertDialog alertDialog10 = builder10.Create();
                alertDialog10.SetTitle("REGISTRO");

                if (Convert.ToInt32(año) > 2017)
                {
                    alertDialog10.SetIcon(Resource.Drawable.Icon);
                    alertDialog10.SetMessage("¿Acaso vienes del Futuro?");
                    alertDialog10.SetButton("OK", (s, ev) =>
                    {

                    });
                    alertDialog10.Show();
                }
                else if (Convert.ToInt32(año) >= 2014 && Convert.ToInt32(año) <= 2017)
                {
                    alertDialog10.SetIcon(Resource.Drawable.Icon);
                    alertDialog10.SetMessage("Eres un bebe muy inteligente, pero no te puedes registrar");
                    alertDialog10.SetButton("OK", (s, ev) =>
                    {

                    });
                    alertDialog10.Show();
                }

                else if (Convert.ToInt32(año) > 1917 && Convert.ToInt32(año) < 2013)
                {
                    obtener_datos();
                    int genero;

                    if (validar_contra() && validar_EditText(txtNombre) && validar_EditText(txtApellidos) && validar_EditText(txtEmail) && txtFechaNac.Text != "" && validarMail(txtEmail))
                    {
                        if (GeneroMasculino.Checked)
                        {
                            genero = 1;
                        }
                        else
                        {
                            genero = 0;
                        }

                        Android.App.AlertDialog.Builder builder5 = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alerDialog5 = builder5.Create();
                        //Titulo
                        alerDialog5.SetTitle("Compra");
                        //Icono
                        alerDialog5.SetIcon(Resource.Drawable.Icon);
                        //Pregunta
                        alerDialog5.SetMessage("Al dar Click en continuar aceptas nuestro Aviso de Privacidad.\n el cual lo puedes consultar en: www.preparate.com/AvisoDePrivacidad");
                        alerDialog5.SetButton("Continuar", (si, eve) =>
                        {

                            try
                            {

                                string res = API0.User.InsertUser(txtNombre.Text, txtApellidos.Text, "", Convert.ToDateTime(txtFechaNac.Text), tContra1.Text, txtEmail.Text, genero, 1, 1, "a");
                                Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
                                AlertDialog alertDialog = builder.Create();
                                alertDialog.SetTitle("REGISTRO");
                                switch (res)
                                {
                                    case "-2":
                                        txtEmail.SetBackgroundColor(Android.Graphics.Color.Red);
                                        alertDialog.SetMessage("La dirección de correo ya existe, por favor ingresa otra dirección ó inicia sesión.");
                                        alertDialog.SetButton("OK", (s, ev) =>
                                        {
                                        });
                                        alertDialog.Show();
                                        break;
                                    default:

                                        alertDialog.SetIcon(Resource.Drawable.Icon);
                                        alertDialog.SetMessage("Registro Exitoso");
                                        alertDialog.SetButton("OK", (s, ev) =>
                                        {
                                            StartActivity(typeof(MenuPrincipal));
                                            Finish();
                                        });
                                        alertDialog.Show();
                                        break;
                                }



                            }

                            catch (Exception ex)
                            {

                            }

                        });

                        alerDialog5.SetButton3("Cancelar", (se, eve) =>
                        {
                            StartActivity(typeof(Crear_Perfil));

                        });
                        alerDialog5.Show();

                    }
                }
                else
                {
                    alertDialog10.SetIcon(Resource.Drawable.Icon);
                    alertDialog10.SetMessage("Eres muy Anciano para usar esta aplicación.");
                    alertDialog10.SetButton("OK", (s, ev) =>
                    {

                    });
                    alertDialog10.Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "Por favor ingresa los datos correctos", ToastLength.Long).Show();
            }

        }

        public void obtener_datos()
        {
            #region Obtiene los datos de los textbox
            tContra1 = FindViewById<EditText>(Resource.Id.tContra1);
            tContra2 = FindViewById<EditText>(Resource.Id.tContra2);
            contra1 = tContra1.Text;
            contra2 = tContra2.Text;
            #endregion
        }
        
        public bool validar_contra()
        {
            bool v = false;
            if (contra1 == contra2)
                v = true;
            else
            {
                tContra1.SetBackgroundColor(Android.Graphics.Color.Red);
                tContra2.SetBackgroundColor(Android.Graphics.Color.Red);
                Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
                AlertDialog alertDialog = builder.Create();
                alertDialog.SetTitle("Mensaje");
                alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                alertDialog.SetMessage("Las contraseñas NO coinciden, Inténtalo de nuevo.");
                alertDialog.SetButton("OK", (s, ev) =>
                {

                });
                alertDialog.Show();
            }
            return v;
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
        private bool validarMail(EditText txtEmail)
        {
            if (txtEmail.Text.Contains("@") && (txtEmail.Text.Contains(".com") || txtEmail.Text.Contains(".edu") || txtEmail.Text.Contains(".gob") || txtEmail.Text.Contains(".mx")))
            {
                return true;
            }
            else
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
        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(Select_Registro));
            StartActivity(intent);
            //base.OnBackPressed(); -> DO NOT CALL THIS LINE OR WILL NAVIGATE BACK
        }
    }


    public class DatePickerFragment : DialogFragment,DatePickerDialog.IOnDateSetListener
    {
        // TAG can be any string of your choice.
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();

        // Initialize this value to prevent NullReferenceExceptions.
        Action<DateTime> _dateSelectedHandler = delegate { };

        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
        {
            DatePickerFragment frag = new DatePickerFragment();
            frag._dateSelectedHandler = onDateSelected;
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currently = DateTime.Now;
            DatePickerDialog dialog = new DatePickerDialog(Activity,
                                                           this,
                                                           currently.Year,
                                                           currently.Month,
                                                           currently.Day);
            return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            // Note: monthOfYear is a value between 0 and 11, not 1 and 12!
            DateTime selectedDate = new DateTime(year, monthOfYear + 1, dayOfMonth);
            Log.Debug(TAG, selectedDate.ToLongDateString());
            _dateSelectedHandler(selectedDate);

        }

       

    }


}