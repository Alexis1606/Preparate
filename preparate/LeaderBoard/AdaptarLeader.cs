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
using Android.Graphics;

namespace preparate
{
    class AdaptarLeader : BaseAdapter<Leader>
    {
        private Context mContext;
        private int mRowLayout;
        private List<Leader> mFriends;
        private int[] mAlternatingColors;

        public AdaptarLeader(Context context, int rowLayout, List<Leader> friends)
        {
            mContext = context;
            mRowLayout = rowLayout;
            mFriends = friends;
            mAlternatingColors = new int[] { 0xF2F2F2, 0xBDAD8C };
        }

        public override int Count
        {
            get { return mFriends.Count; }
        }

        public override Leader this[int position]
        {
            get { return mFriends[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(mRowLayout, parent, false);
            }

            row.SetBackgroundColor(GetColorFromInteger(mAlternatingColors[position % mAlternatingColors.Length]));


            TextView Puntaje = row.FindViewById<TextView>(Resource.Id.txtPuntaje);
            Puntaje.Text = mFriends[position].Puntaje;

            TextView Examen = row.FindViewById<TextView>(Resource.Id.txtExamen);
            Examen.Text = mFriends[position].Examen;

            TextView Nombre = row.FindViewById<TextView>(Resource.Id.txtNombre);
            Nombre.Text = mFriends[position].Nombre;


            if ((position % 2) == 1)
            {
                //Green background, set text white
                Puntaje.SetTextColor(Color.White);
                Examen.SetTextColor(Color.White);
                Nombre.SetTextColor(Color.White);
            }

            else
            {
                //White background, set text black
                Puntaje.SetTextColor(Color.Black);
                Examen.SetTextColor(Color.Black);
                Nombre.SetTextColor(Color.Black);
            }
            return row;
        }

        private Color GetColorFromInteger(int color)
        {
            return Color.Rgb(Color.GetRedComponent(color), Color.GetGreenComponent(color), Color.GetBlueComponent(color));
        }
    }
}