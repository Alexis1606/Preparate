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
using System.Timers;

namespace preparate
{
    [Activity(Label = "ExamenesCompletos")]
    public class ExamenesCompletos : Activity
    {
        Button bEnviar;
        Button bEmpezar;
        TextView pregunta;
        RadioGroup Opciones;
        Button Enviar;
        Spinner spinner1;
        Spinner spinner2;
        TextView textSegundos;
        TextView txtTiempo;
        TextView textCantidad;
        Timer timer;
        TextView txtSelecciona;
        int mins = 0, secs = 0, milliseconds = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ExamenesCompletos);

            spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);
            spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.listaTiempo, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adapter;

            spinner2 = FindViewById<Spinner>(Resource.Id.spinner2);
            spinner2.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            var adapter2 = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.listaCantidadPreg, Android.Resource.Layout.SimpleSpinnerItem);
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner2.Adapter = adapter2;

            bEnviar = FindViewById<Button>(Resource.Id.bEnviar);

            bEnviar.Click += Aceptar_Click;


            bEmpezar = FindViewById<Button>(Resource.Id.bEmpezar);
            bEmpezar.Click += Empezar_Click;

            pregunta = FindViewById<TextView>(Resource.Id.pregunta);

            Opciones = FindViewById<RadioGroup>(Resource.Id.Opciones);
            textSegundos = FindViewById<TextView>(Resource.Id.textSegundos);
            txtTiempo = FindViewById<TextView>(Resource.Id.txtTiempo);
            textCantidad = FindViewById<TextView>(Resource.Id.textCantidad);
            txtSelecciona = FindViewById<TextView>(Resource.Id.txtSelecciona);
        }

        private void Empezar_Click(object sender, EventArgs e)
        {
            pregunta.Visibility = ViewStates.Visible;
            Opciones.Visibility = ViewStates.Visible;
            bEnviar.Visibility = ViewStates.Visible;
            spinner1.Visibility = ViewStates.Invisible;
            spinner2.Visibility = ViewStates.Invisible;
            bEmpezar.Visibility = ViewStates.Invisible;
            textSegundos.Visibility = ViewStates.Invisible;
            txtSelecciona.Visibility = ViewStates.Invisible;
            textCantidad.Visibility = ViewStates.Invisible;
            timer = new Timer();
            timer.Interval = 1; //milliseconds
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            milliseconds++;
            if (milliseconds >= 1000)
            {
                secs++;
                milliseconds = 0;
            }
            if (secs == 59)
            {
                mins++;
                secs = 0;
            }
            RunOnUiThread(() =>
            {
                txtTiempo.Text = string.Format("{0}: {1:00}:{2:000}", mins, secs, milliseconds);
            });
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            timer.Stop();
            //StartActivity(typeof(Resultado));
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alerDialog = builder.Create();

            //Titulo
            alerDialog.SetTitle("FELICITACIONES");
            //Icono
            alerDialog.SetIcon(Resource.Drawable.CopaGanador);
            //Pregunta
            alerDialog.SetMessage("Haz Obtenido: " + "100" + " Puntos en " + "20" + " Segundos");
            alerDialog.SetButton("ACEPTAR", (se, eve) =>
            {

                StartActivity(typeof(MenuPrincipal));
            });
            alerDialog.Show();

        }
    }
}