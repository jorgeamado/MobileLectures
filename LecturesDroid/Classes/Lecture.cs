using System.Collections.Generic;
using System.Xml.Serialization;
using System;

namespace LecturesDroid
{
	[Serializable]
	public class BaseCategory
	{
        [XmlIgnore]
        public BaseCategory Parent;

		[XmlAttribute("name")]
		public string Name = "lecture name";
		public BaseCategory()
		{
		}
	}

	[Serializable]
	public class Category : BaseCategory
	{
		[XmlElement(typeof(BaseCategory))]
		[XmlElement(typeof(Category))]
		[XmlElement(typeof(Lecture))]
		public List<BaseCategory> SubCategories = new List<BaseCategory>();
		public Category()
		{
		}
	}

	[Serializable]
	public class Lecture : BaseCategory
	{
		[XmlElement("text")]
		public string LectureText = "lecture text";
		public Lecture()
		{
		}
	}
}

