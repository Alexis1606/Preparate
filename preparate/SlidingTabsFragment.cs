using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Android.Preferences;

namespace preparate
{
    
    public class SlidingTabsFragment : Fragment
    {
     
           
        private SlidingTabScrollView mSlidingTabScrollView;
        private ViewPager mViewPager;



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            return inflater.Inflate(Resource.Layout.fragment_sample, container, false);
            
        }




        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            mSlidingTabScrollView = view.FindViewById<SlidingTabScrollView>(Resource.Id.sliding_tabs);
            mViewPager = view.FindViewById<ViewPager>(Resource.Id.viewpager);
            mViewPager.Adapter = new SamplePagerAdapter();            
            mSlidingTabScrollView.ViewPager = mViewPager;


        }

        public class SamplePagerAdapter : PagerAdapter
        {
            List<string> items = new List<string>();

            public SamplePagerAdapter() : base()
            {
                items.Add("Estadísticas Quiz");
                items.Add("Temas de Repaso");
            }

            public override int Count
            {
                get { return items.Count; }

            }

            public override bool IsViewFromObject(View view, Java.Lang.Object obj)
            {
                return view == obj;
            }
            TextView ExamenSpin;
            Spinner s1;
            EditText et;
            API0.TipoExamen[] te;
            int user = 0;
            int IDExam = 1;
            public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
            {
                

                View view = LayoutInflater.From(container.Context).Inflate(Resource.Layout.pager_item, container, false);
                container.AddView(view);
                


                if (position == 0)
                {
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(container.Context);
                    int  user = prefs.GetInt("user", 0);
                    string respuestas = API0.Estadisticas.GetRespuestasCorrectasXUsuario(user);
                    TextView prueba = view.FindViewById<TextView>(Resource.Id.Prueba2);
                    prueba.Text = respuestas;

                    TextView Examenes = view.FindViewById<TextView>(Resource.Id.Prueba4);
                    string examenes = API0.Estadisticas.GetExamenesHechos(user);
                    Examenes.Text = examenes;

                    s1 = view.FindViewById<Spinner>(Resource.Id.spinner1);
                    et = view.FindViewById<EditText>(Resource.Id.editText1);

                    te = API0.TipoExamen.allbyuser(user);
                    var items = new List<string>()
                    { };
                    foreach (API0.TipoExamen t in te)
                    {
                        items.Add(t.desc);
                    }
                    var adapter = new ArrayAdapter<string>(container.Context, Android.Resource.Layout.SimpleSpinnerItem, items);
                    s1.Adapter = adapter;
                    s1.ItemSelected += spinner1_ItemSelected;
                    IDExam = te[1].id;
                    TextView prueba3 = view.FindViewById<TextView>(Resource.Id.Prueba6);
                    prueba3.Text = API0.Estadisticas.GetVecesRealizadasXExamen(user, IDExam);
                }


                if (position == 1)
                {
                   //s1.RemoveView(view.FindViewById<Spinner>(Resource.Id.spinner1));
       
                    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(container.Context);
                     user = prefs.GetInt("user", 0);
                    string respuestas = API0.Estadisticas.GetPorcentajeTemamenor80(user);
                    TextView prueba = view.FindViewById<TextView>(Resource.Id.Prueba);
                    prueba.Text = respuestas;

                    TextView prueba2 = view.FindViewById<TextView>(Resource.Id.Prueba2);
                    prueba2.Text = " ";
                    TextView prueba3 = view.FindViewById<TextView>(Resource.Id.Prueba3);
                    prueba3.Text = " ";
                    TextView prueba4 = view.FindViewById<TextView>(Resource.Id.Prueba4);
                    prueba4.Text = " ";
                    TextView prueba5 = view.FindViewById<TextView>(Resource.Id.Prueba5);
                    prueba5.Text = " ";
                    TextView prueba6 = view.FindViewById<TextView>(Resource.Id.Prueba6);
                    prueba6.Text = " ";




                }

                //if (position == 2)
                //{
                //    ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(container.Context);
                //    int user = prefs.GetInt("user", 0);
                //    TextView Examenes = view.FindViewById<TextView>(Resource.Id.Prueba);
                //    string examenes = API0.Estadisticas.GetExamenesHechos(user);
                //    Examenes.Text = examenes;
                //}

                //TextView txtTitle = view.FindViewById<TextView>(Resource.Id.item_title);
                //int pos = position + 1;
                //txtTitle.Text = pos.ToString();




                return view;
            }

            private void spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
            {

                //et.Text = API0.Estadisticas.GetVecesRealizadasXExamen(user, 1);

            }

            public string GetHeaderTitle(int position)
            {
                return items[position];
            }

            public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object obj)
            {
                container.RemoveView((View)obj);
            }
        }
    }
}