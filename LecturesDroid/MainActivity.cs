using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace LecturesDroid
{
    [Activity(Label = "LecturesDroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ListView categoriesList;

        private BaseCategory currentCategory;
        public BaseCategory CurrentCategory
        {
            get { return currentCategory; }
            set
            {
                if(value is Category)
                    currentCategory = value;
                UpdateLaypout(value);
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            categoriesList = FindViewById<ListView>(Resource.Id.categorieslistView);
            Button backButton = FindViewById<Button>(Resource.Id.button1);

            categoriesList.Adapter = new LecturesAdapter(this);
            backButton.Click += (sender, e) =>
            {
                var adapter = (categoriesList.Adapter as LecturesAdapter);
                if (null != adapter.CurrentCategory.Parent)
                {
                    CurrentCategory = CurrentCategory.Parent;
                }
            };
        }

        void UpdateLaypout(BaseCategory category)
        {
            categoriesList.Enabled = false;
            if (category is Category)
            {
                (categoriesList.Adapter as LecturesAdapter).CurrentCategory = category as Category;
                categoriesList.Adapter = categoriesList.Adapter;
            }
            else
            {
                var intent = new Intent(this, typeof(LectureTextActivity));
                intent.PutExtra("lecture", (category as Lecture).LectureText);
                StartActivity(intent);
            }
        }
    }
}


