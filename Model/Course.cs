using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace School.Model
{
    public class Course
    {
        private string? _name;
        private int? _edition;
        private List<Lesson> _lessons;
        private List<Student> _cstudents;

        public Course() 
        {
            _lessons = new List<Lesson>();
            _cstudents = new List<Student>();
        }
        public string? Name  
        {
            get => _name;
            set => _name = value;
        }
        public int? Edition
        {
            get => _edition;
            set => _edition = value;
        }
        public List<Lesson> Lessons
        {
            get => _lessons;
        }
        public List<Student> Students
        {
            get => _cstudents;
        }
        public override string ToString()
        {
            return " COURSE ==  " + " Name: " + Name + " Edition: " + Edition;
        }

        public static void SerializeListOfStudent()
        {
            try
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
                Student stud3 = new Student();
                stud3.Name = "Fabian";
                stud3.Surname = "Ruiz";
                stud3.Number = "N1894";
                Student stud4 = new Student();
                stud4.Name = "Giovanni";
                stud4.Surname = "Di Lorenzo";
                stud4.Number = "N67124";
                Student stud5 = new Student();
                stud5.Name = "Alex";
                stud5.Surname = "Meret";
                stud5.Number = "N64670";
                Student stud6 = new Student();
                stud6.Name = "David";
                stud6.Surname = "Ospina";
                stud6.Number = "N60032";
                Student stud7 = new Student();
                stud7.Name = "Mario";
                stud7.Surname = "Rui";
                stud7.Number = "N6892";

                students.Add(stud1);
                students.Add(stud2);
                students.Add(stud3);
                students.Add(stud4);
                students.Add(stud5);
                students.Add(stud6);
                students.Add(stud7);

                ListOfStudents myStudents = new ListOfStudents();
                myStudents.Students = students.ToArray();
                string sourcePath = ConfigurationManager.AppSettings["CourseStudents"];
                Console.WriteLine(File.Exists(sourcePath) ? "File exists." : "File does not exist.");
                XmlSerializer serializer = new XmlSerializer(typeof(ListOfStudents));
                TextWriter writer = new StreamWriter(sourcePath);
                serializer.Serialize(writer, myStudents);
                writer.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadStudents()
        {
            try
            {
                string sourcePath = ConfigurationManager.AppSettings["CourseStudents"];
                Console.WriteLine(File.Exists(sourcePath) ? "File exists." : "File does not exist.");
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
                        _cstudents.Add(s);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void SerializeListOfLessons()
        {
            try
            {
                List<Lesson> lessons = new List<Lesson>();
                Lesson less1 = new Lesson();
                less1.Descr = "Introduction to Signal Theory";
                less1.Date = DateTime.Parse("25/10/2020", CultureInfo.CurrentCulture);
                less1.StartTime = 10;
                less1.Duration = 2;
                Lesson less2 = new Lesson();
                less2.Descr = "PDF and CDF";
                less2.Date = DateTime.Parse("25/12/2020", CultureInfo.CurrentCulture);
                less2.StartTime = 8;
                less2.Duration = 2;
                Lesson less3 = new Lesson();
                less3.Descr = "Query and trigger";
                less3.Date = DateTime.Parse("22/11/2020", CultureInfo.CurrentCulture);
                less3.StartTime = 8;
                less3.Duration = 2;
                Lesson less4 = new Lesson();
                less4.Descr = "Newton's Law";
                less4.Date = DateTime.Parse("22/11/2020", CultureInfo.CurrentCulture);
                less4.StartTime = 12;
                less4.Duration = 2;
                Lesson less5 = new Lesson();
                less5.Descr = "Termodynamic";
                less5.Date = DateTime.Parse("26/11/2020", CultureInfo.CurrentCulture);
                less5.StartTime = 8;
                less5.Duration = 2;

                lessons.Add(less1);
                lessons.Add(less2);
                lessons.Add(less3);
                lessons.Add(less4);
                lessons.Add(less5);

                ListOfLessons myLessons = new ListOfLessons();
                myLessons.Lessons = lessons.ToArray();
                string sourcePath = ConfigurationManager.AppSettings["Lessons"];
                Console.WriteLine(File.Exists(sourcePath) ? "File exists." : "File does not exist.");
                XmlSerializer serializer = new XmlSerializer(typeof(ListOfLessons));
                TextWriter writer = new StreamWriter(sourcePath);
                serializer.Serialize(writer, myLessons);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void LoadLessons(string sourcePath)
        {
            try
            {
                Console.WriteLine(File.Exists(sourcePath) ? "File exists." : "File does not exist.");
                XmlSerializer serializer = new XmlSerializer(typeof(ListOfLessons));
                StreamReader reader = new StreamReader(sourcePath);
                ListOfLessons myLessons = new ListOfLessons();
                myLessons = (ListOfLessons)serializer.Deserialize(reader);
                reader.Close();

                if (myLessons != null)
                {
                    for (int i = 0; i < myLessons.Lessons.Length; i++)
                    {
                        Lesson l = myLessons.Lessons[i];
                        _lessons.Add(l);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
