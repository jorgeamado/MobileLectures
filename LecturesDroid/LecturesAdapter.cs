using Android.App;
using Android.Widget;
using Android.Views;
using System.Xml.Serialization;
using System.IO;
using Android.Speech.Tts;
using Java.IO;
using Android.Content.Res;
using Android.Text;

namespace LecturesDroid
{
	public class LecturesAdapter : BaseAdapter<string>
	{
		Category MainCategory;
		Category currentCategory;

		Activity context;
		ListView owner;

		public LecturesAdapter(Activity context, ListView owner) : base()
		{
			this.context = context;
			this.owner = owner;

			using(var fileStream = this.context.Assets.Open("LecturesStructure.xml"))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Category));
				this.MainCategory =	xmlSerializer.Deserialize(fileStream) as Category;
				this.currentCategory = MainCategory;
			}
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override string this[int position]
		{   
			get { return this.currentCategory.SubCategories[position].Name; } 
		}

		public override int Count
		{
			get { return this.currentCategory.SubCategories.Count; } 
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView; // re-use an existing view, if one is available
			if (view == null)
				{ // otherwise create a new one
					view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
				}
			var textView = view.FindViewById<TextView>(Android.Resource.Id.Text1);

			//TODO create custom view
			var category = this.currentCategory.SubCategories[position];
			textView.Text = category.Name;
			textView.Click += (sender, e) => 
				{
					System.Console.WriteLine(sender);

					if(category is Category)
					{
						this.currentCategory = category as Category;
						//TODO update list after
					}
				};
			return view;
		}
	}
}

