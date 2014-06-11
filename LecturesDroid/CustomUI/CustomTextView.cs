
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

namespace LecturesDroid
{
	public class CustomTextView : TextView
	{
		private BaseCategory category;
		public BaseCategory Category
		{
			get
			{
				return category;
			}
			set
			{
				category = value;
				if(null != category)
					this.Text = category.Name;
			}
		}

		public CustomTextView(Context context)
			: base(context)
		{
			Initialize();
		}

		public CustomTextView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Initialize();
		}

		public CustomTextView(Context context, IAttributeSet attrs, int defStyle)
			: base(context, attrs, defStyle)
		{
			Initialize();
		}

		protected CustomTextView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
			Initialize();
		}


		void Initialize()
		{
		}
	}
}

