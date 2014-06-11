using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace LecturesDroid
{
    [Activity(Label = "LectureTextActivity")]			
    public class LectureTextActivity : Activity
    {
        public Lecture lecture;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LectureTextLayout);
            var lectureTextView = FindViewById<TextView>(Resource.Id.textView1);

            lectureTextView.Text = Intent.GetStringExtra("lecture") ?? "Data not available";
            var backButton = FindViewById<Button>(Resource.Id.button1);

            backButton.Click += (sender, e) =>
            {
                Finish();
            };
        }
    }
}

