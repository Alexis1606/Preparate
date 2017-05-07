using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using API0;
using Classes;
using Android.Preferences;
using Android.Graphics;
using System.Net;



namespace preparate
{
    [Activity(Label = "Quiz")]
    public class Quiz : Activity
    {
        Button bEnviar;
        //Button bEmpezar;
        TextView pregunta;
        EditText Respuesta;
        RadioGroup Opciones;
        TextView ContadorPreg;
        //Button Enviar;
        //Spinner spinner1;
        //TextView textSegundos;
//        TextView txtTiempo;
        TextView Validar;
        //      Timer timer;
        //TextView txtSelecciona;
        //int mins = 0, secs = 0, milliseconds = 1;
        Pregunta pre;
        ImageView imagen;
        RadioButton[] r;
        int contPregunta;
        int calificacion;
        int examen;
        string con = "Data Source=alexisserver.ceq0e9y8bekm.us-west-2.rds.amazonaws.com;Initial Catalog=preparate_dev;Persist Security Info=True;User ID=Alexis;Password=Proyecto2017";
        bool correcta ;
        int respusu = 0;
        ProgressBar pb;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            examen = 1;
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Quiz);

            //spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);
            //spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            //var adapter = ArrayAdapter.CreateFromResource(
            //        this, Resource.Array.listaTiempo, Android.Resource.Layout.SimpleSpinnerItem);
            //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            //spinner1.Adapter = adapter;

            bEnviar = FindViewById<Button>(Resource.Id.bEnviar);

            bEnviar.Click += Aceptar_Click;


            //bEmpezar = FindViewById<Button>(Resource.Id.bEmpezar);
            //bEmpezar.Click += Empezar_Click;

            pregunta = FindViewById<TextView>(Resource.Id.pregunta);

            Opciones = FindViewById<RadioGroup>(Resource.Id.Opciones);
            //textSegundos = FindViewById<TextView>(Resource.Id.textSegundos);
            //txtTiempo = FindViewById<TextView>(Resource.Id.txtTiempo);
            //txtSelecciona = FindViewById<TextView>(Resource.Id.txtSelecciona);
            Validar = FindViewById<TextView>(Resource.Id.txtValidar);
            Respuesta = FindViewById<EditText>(Resource.Id.TextboxQuiz);
            imagen = FindViewById<ImageView>(Resource.Id.ImagenQuiz);
            ContadorPreg = FindViewById<TextView>(Resource.Id.ContPreguntas);
            pre = Pregunta.obtenerAleatoria(examen);
            r = new RadioButton[]
            {
                FindViewById<RadioButton>(Resource.Id.opcion1),
                FindViewById<RadioButton>(Resource.Id.Opcion2),
                FindViewById<RadioButton>(Resource.Id.Opcion3),
                FindViewById<RadioButton>(Resource.Id.Opcion4),
                FindViewById<RadioButton>(Resource.Id.Opcion5),
                FindViewById<RadioButton>(Resource.Id.Opcion6),
                FindViewById<RadioButton>(Resource.Id.Opcion7),
                FindViewById<RadioButton>(Resource.Id.Opcion8),
                FindViewById<RadioButton>(Resource.Id.Opcion9),
                FindViewById<RadioButton>(Resource.Id.Opcion10),
                FindViewById<RadioButton>(Resource.Id.Opcion11)
            };
            mostrarPregunta(pre);
            contPregunta = 0;
            calificacion = 0;
            pb = FindViewById<ProgressBar>(Resource.Id.progressBar1);
        }

        private void Empezar_Click(object sender, EventArgs e)
        {
            pregunta.Visibility = ViewStates.Visible;
            Opciones.Visibility = ViewStates.Visible;
            bEnviar.Visibility = ViewStates.Visible;
            //spinner1.Visibility = ViewStates.Invisible;
            //bEmpezar.Visibility = ViewStates.Invisible;
            Validar.Visibility = ViewStates.Invisible;
            //textSegundos.Visibility = ViewStates.Invisible;
            //txtSelecciona.Visibility = ViewStates.Invisible;
            //timer = new Timer();
            //timer.Interval = 1; //milliseconds
            //timer.Elapsed += Timer_Elapsed;
            //timer.Start();

        }

        ////private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    milliseconds++;
        //    if (milliseconds >= 1000)
        //    {
        //        secs++;
        //        milliseconds = 0;
        //    }
        //    if (secs == 59)
        //    {
        //        mins++;
        //        secs = 0;
        //    }
        //    RunOnUiThread(() =>
        //    {
        //        txtTiempo.Text = string.Format("{0}: {1:00}:{2:000}", mins, secs, milliseconds);
        //    });
        //}

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            //subir respuesta del usuario a base de datos            
            contPregunta++;
            ContadorPreg.Text = contPregunta + " de 10";
            if (contPregunta <= 10)
            {
                int i;
               
                for (i = 0; i < r.Length; i++)
                {
                    if (r[i].Selected || r[i].Checked)
                        break;
                }
                if (i < r.Length)
                {

                    if (validarRespuesta(pre, i) == 1)
                    {
                        calificacion++;
                        Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alerDialog = builder.Create();
                        alerDialog.SetTitle("FELICITACIONES");
                        
                        alerDialog.SetIcon(Resource.Drawable.Bien);
                        alerDialog.SetMessage("Felicidades, respuesta correcta");
                        alerDialog.Show();
                        correcta = true;
                        respusu = i;
                    }
                    else
                    {
                        Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                        Android.App.AlertDialog alerDialog = builder.Create();
                        alerDialog.SetTitle("Respuesta incorrecta");
                        //poner imagen de respuesta incorrecta
                        alerDialog.SetIcon(Resource.Drawable.Mal);
                        alerDialog.SetMessage(pre.ayuda);
                        alerDialog.Show();
                        correcta = false;
                        respusu = i;
                    }
                    pre = Pregunta.obtenerAleatoria(examen);
                    mostrarPregunta(pre);
                    r[10].Visibility = ViewStates.Gone;
                    r[10].Checked = true;
                    r[10].Selected = true;
                }
                else
                {
                    Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alerDialog = builder.Create();
                    alerDialog.SetTitle("Error");
                    //poner imagen de seleccionar una opci[on
                    //alerDialog.SetIcon(Resource.Drawable.CopaGanador);
                    alerDialog.SetMessage("Debes seleccionar una opción");
                    alerDialog.Show();
                }

            }else
            {
                Validar.Visibility = ViewStates.Visible;
                //timer.Stop();
                //StartActivity(typeof(Resultado));
                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alerDialog = builder.Create();

                //Titulo
                alerDialog.SetTitle("FELICITACIONES");
                //Icono
                alerDialog.SetIcon(Resource.Drawable.CopaGanador);
                //Pregunta
                alerDialog.SetMessage("Haz Obtenido: " + (calificacion*10) + " Puntos");
                alerDialog.SetButton("ACEPTAR", (se, eve) =>
                {

                    StartActivity(typeof(MenuPrincipal));
                });
                alerDialog.Show();
            }

            //---------------RespuestaUsuario
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            // ID de usuario
            int userid = prefs.GetInt("user", 0);
            User Datos = new User(userid);
            String NOM = Datos.Nombre;
            int preid = pre.idPregunta;
            DateTime thisDay = DateTime.Today;
            int respcorr = pre.opcCorrecta;

            Classes.Parameter[] p = new Classes.Parameter[] {

                new Classes.Parameter ("@ID_Usuario",userid),
                new Classes.Parameter ("@ID_Pregunta",preid),
                new Classes.Parameter ("@Fecha",thisDay),
                new Classes.Parameter ("@Respuesta_Usuario",respusu),
                new Classes.Parameter ("@Respuesta_Correcta",respcorr),
                new Classes.Parameter ("@Tiempo",null),
                new Classes.Parameter ("@Coorecta",correcta)

            };

            int ID = Convert.ToInt32(MSSql.FirstDataFromTable(con, "InsertRespuestasAlumnos", p));


            MSSql.FirstDataFromTable(con, "InsertRespuestasAlumnos", p);
            respusu = 0;
            //---------------RespuestaUsuario


        }

        private void mostrarPregunta(Pregunta p)
        {
            pregunta.Text = p.pregunta;
            pregunta.Visibility = ViewStates.Visible;
            switch (p.tipo)
            {
                case 3:
                    Opciones.Visibility = ViewStates.Visible;
                    Respuesta.Visibility = ViewStates.Gone;
                    int i;
                    for (i = 0; i < p.opciones.Length; i++)
                    {
                        r[i].Visibility = ViewStates.Visible;
                        r[i].Text = p.opciones[i];
                    }
                    for(i = i; i < r.Length; i++)
                    {
                        r[i].Visibility = ViewStates.Gone;
                    }


                    break;
                case 4:
                    break;
            }
            if (p.imagen == "")
            {
                imagen.Visibility = ViewStates.Gone;
            }else
            {



                imagen.Visibility = ViewStates.Visible;
                var imageBitmap = GetImageBitmapFromUrl(p.imagen);
                imagen.SetImageBitmap(imageBitmap);


                //Android.Net.Uri u = Android.Net.Uri.Parse(p.imagen);
                //imagen.SetImageURI(Android.Net.Uri.Parse(p.imagen));
            }
            pb.Progress = 5;
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        private int validarRespuesta(Pregunta p, int respuesta)
        {
            if (respuesta == p.opcCorrecta)
                return 1;
            else
                return 0;
        }


    }
}