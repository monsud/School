using System.Xml.Serialization;

namespace School.Model
{
    public class ListOfCourses
    {
        [XmlArrayItem(ElementName = "Course", IsNullable = true, Type = typeof(Course))]
        [XmlArray]
        private Course[] courses;
        public Course[] Courses

        {
            get { return courses; }
            set { courses = value; }
        }
    }
}
