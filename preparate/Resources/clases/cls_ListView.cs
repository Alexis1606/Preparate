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

    public class cls_ListView
    {
        /*VARIABLES*/
        int _idExamen;
        string _TipodeExamen;
        string _Examen;


        /*CONSTRUCTOR*/
        public cls_ListView(int _idExamen,
                         string TipodeExamen,
                         string Examen
                         )
        {

            this._idExamen = _idExamen;
            this._TipodeExamen = TipodeExamen;
            this._Examen = Examen;
        }

        /*PROPIEDADES*/

        public string Examen
        {
            get
            {
                return _Examen;
            }
            set
            {

                _Examen = value;
            }
        }

        public string tipodeExamen
        {
            get
            {
                return _TipodeExamen;
            }
            set
            {
                _TipodeExamen = value;
            }
        }

        public int Id_Tipo
        {
            get
            {
                return _idExamen;
            }
            set
            {
                _idExamen = value;
            }
        }
    }
}