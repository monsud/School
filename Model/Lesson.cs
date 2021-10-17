using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace School.Model
{
    public class Lesson
    {
        private string? _descr;
        private DateTime? _date;
        private int? _start;
        private int? _duration;
        private Professor _myProfessor;
        private Room _myRoom;
        private List<Student> _students;
        public Lesson() 
        {
            _students = new List<Student>();
        }
        public string? Descr
        {
            get => _descr;
            set => _descr = value;
        }
        public DateTime? Date
        {
            get => _date;
            set => _date = value;
        }
        public int? StartTime
        {
            get => _start;
            set => _start = value;
        }
        public int? Duration
        {
            get => _duration;
            set => _duration = value;
        }
        public Professor MyProfessor
        {
            get => _myProfessor;
            set => _myProfessor = value;
        }
        public Room MyRoom
        {
            get => _myRoom;
            set => _myRoom = value;
        }
        public List<Student> Students
        {
            get => _students;
        }
        public static void SerializeListOfLessStudent()
        {
            List<Student> students = new List<Student>();
            Student stud1 = new Student();
            stud1.Name = "Lorenzo";
            stud1.Surname = "Insigne";
            stud1.Number = "N4959";
            Student stud2 = new Student();
            stud2.Name = "Ciro";
            stud2.Surname = "Mertens";
            stud2.Number = "N46503";

            students.Add(stud1);
            students.Add(stud2);

            ListOfStudents myStudents = new ListOfStudents();
            myStudents.Students = students.ToArray();
            string sourcePath = ConfigurationManager.AppSettings["LessonsStudents"];
            XmlSerializer serializer = new XmlSerializer(typeof(ListOfStudents));
            TextWriter writer = new StreamWriter(sourcePath);
            serializer.Serialize(writer, myStudents);
            writer.Close();
        }

        public void LoadLessStudents(string sourcePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ListOfStudents));
            StreamReader reader = new StreamReader(sourcePath);
            ListOfStudents myStudents = new ListOfStudents();
            myStudents = (ListOfStudents)serializer.Deserialize(reader);
            reader.Close();

            if (myStudents != null)
            {
                for (int i = 0; i < myStudents.Students.Length; i++)
                {
                    Student s = myStudents.Students[i];
                    _students.Add(s);
                }
            }
            else
                throw new Exception("List of student is empty.");
        }
        public override string ToString()
        {
            return " LESSON ==  " + " Description: " + Descr + " Date: " + Date + " Duration: " + Duration;
        }
    }
}
