using System.Xml.Serialization;

namespace School.Model
{
    public class ListOfStudents
    {
        [XmlArrayItem(ElementName = "Student", IsNullable = true, Type = typeof(Student))]
        [XmlArray]
        private Student[] students;
        public Student[] Students

        {
            get { return students; }
            set { students = value; }
        }
    }
}
