using System.Xml.Serialization;

namespace School.Model
{
    public class ListOfLessons
    {
        [XmlArrayItem(ElementName = "Lesson", IsNullable = true, Type = typeof(Lesson))]
        [XmlArray]
        private Lesson[] lessons;
        public Lesson[] Lessons

        {
            get { return lessons; }
            set { lessons = value; }
        }
    }
}
