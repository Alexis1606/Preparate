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
    [Activity(Label = "Modificar Datos", Icon = "@drawable/Icon")]
    public class ModificarPerfil : Activity
    {
        EditText txtNombre;
        EditText txtApellidos;
        EditText txtEmail;
        EditText txtFechaNac;
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

            SetContentView(Resource.Layout.ModificarPerfil);
        }
    }
}