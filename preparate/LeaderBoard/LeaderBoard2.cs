using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views.InputMethods;
using System.Linq;
using System.Data;

namespace preparate
{
    [Activity(Label = "LEADERBOARD", Icon = "@drawable/Icon")]
    public class LeaderBoard2 : Activity
    {
        private List<Leader> mFriends;
        private ListView mListView;
        private EditText mSearch;
        private LinearLayout mContainer;
        private bool mAnimatedDown;
        private bool mIsAnimating;
        private AdaptarLeader mAdapter;
        API0.TipoExamen[] te;
        int user;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LeaderBoard2);
            mListView = FindViewById<ListView>(Resource.Id.listView);
            mSearch = FindViewById<EditText>(Resource.Id.etSearch);
            mContainer = FindViewById<LinearLayout>(Resource.Id.llContainer);

            mSearch.Alpha = 0;
            mSearch.TextChanged += mSearch_TextChanged;

            mFriends = new List<Leader>();

            foreach (DataRow row in API0.Leaderboard.get_leadboard(0).Rows)
            {

                mFriends.Add(new Leader {  Puntaje = row["Puntaje"].ToString(), Examen = row["Examen"].ToString(), Nombre = row["Nombre"].ToString(), });
                mAdapter = new AdaptarLeader(this, Resource.Layout.row_Leader, mFriends);
                mListView.Adapter = mAdapter;

            }
            
        }

        void mSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {

            List<Leader> searchedFriends = (from friend in mFriends
                                            where friend.Puntaje.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase) || friend.Examen.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)
                                            || friend.Nombre.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)
                                            select friend).ToList<Leader>();

            mAdapter = new AdaptarLeader(this, Resource.Layout.row_Leader, searchedFriends);
            mListView.Adapter = mAdapter;


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbarSearch, menu);
            return base.OnCreateOptionsMenu(menu);
        }





        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu:
                    StartActivity(typeof(MenuPrincipal));
                    return true;

                case Resource.Id.search:
                    //Search icon has been clicked

                    if (mIsAnimating)
                    {
                        return true;
                    }

                    if (!mAnimatedDown)
                    {
                        //Listview is up
                        MyAnimation anim = new MyAnimation(mListView, mListView.Height - mSearch.Height);
                        anim.Duration = 500;
                        mListView.StartAnimation(anim);
                        anim.AnimationStart += anim_AnimationStartDown;
                        anim.AnimationEnd += anim_AnimationEndDown;
                        mContainer.Animate().TranslationYBy(mSearch.Height).SetDuration(500).Start();
                    }

                    else
                    {
                        //Listview is down
                        MyAnimation anim = new MyAnimation(mListView, mListView.Height + mSearch.Height);
                        anim.Duration = 500;
                        mListView.StartAnimation(anim);
                        anim.AnimationStart += anim_AnimationStartUp;
                        anim.AnimationEnd += anim_AnimationEndUp;
                        mContainer.Animate().TranslationYBy(-mSearch.Height).SetDuration(500).Start();
                    }

                    mAnimatedDown = !mAnimatedDown;
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        void anim_AnimationEndUp(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
            mSearch.ClearFocus();
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }

        void anim_AnimationEndDown(object sender, Android.Views.Animations.Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
        }

        void anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearch.Animate().AlphaBy(1.0f).SetDuration(500).Start();
        }

        void anim_AnimationStartUp(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearch.Animate().AlphaBy(-1.0f).SetDuration(300).Start();
        }
    }
}

