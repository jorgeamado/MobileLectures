using Android.Widget;
using Android.Views;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System;

namespace LecturesDroid
{
    public class LecturesAdapter : BaseAdapter<string>
    {
        public Category CurrentCategory;
        MainActivity context;

        public LecturesAdapter(MainActivity context)
            : base()
        {
            this.context = context;

            using (var fileStream = this.context.Assets.Open("LecturesStructure.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Category));
                this.CurrentCategory =	xmlSerializer.Deserialize(fileStream) as Category;
                CreateHierarchy();
            }
        }

        void CreateHierarchy()
        {
            Queue<Category> categories = new Queue<Category>();
            categories.Enqueue(CurrentCategory);
            while (categories.Count > 0)
            {
                var current = categories.Dequeue();
                foreach (var subcagory in current.SubCategories)
                {
                    subcagory.Parent = current;
                    if (subcagory is Category)
                    {
                        categories.Enqueue(subcagory as Category);
                    }
                }
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override string this [int position]
        {   
            get { return CurrentCategory.SubCategories[position].Name; } 
        }

        public override int Count
        {
            get { return CurrentCategory.SubCategories.Count; } 
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null)
            { // otherwise create a new one
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }
            var textView = view.FindViewById<CustomTextView>(Android.Resource.Id.Text1);

            textView.Category = CurrentCategory.SubCategories[position];
            textView.Click += (sender, e) =>
            {
                textView.Category.Parent = CurrentCategory;
                this.context.CurrentCategory = textView.Category;
            };

            return view;
        }
    }
}

