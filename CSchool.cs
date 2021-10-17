using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using School.Model;

namespace School
{
    public class CSchool
    {
        const int percentage = 100;
        private List<Course> _courses;
        public CSchool()
        {
            _courses = new List<Course>();
        }
        public double GetAvg(double sum, double tot)
        {
            return sum / tot;
        }
        public double GetPercentage(double sum, double tot)
        {
            return GetAvg(sum, tot) * percentage;
        }

        public static void SerializeListOfCourses()
        {
            try
            {
                List<Course> courses = new List<Course>();
                Course course1 = new Course();
                course1.Name = "Signal Theory";
                course1.Edition = 2020;
                Course course2 = new Course();
                course2.Name = "Physic 1";
                course2.Edition = 2019;
                Course course3 = new Course();
                course3.Name = "Database";
                course3.Edition = 2020;

                courses.Add(course1);
                courses.Add(course2);
                courses.Add(course3);

                ListOfCourses myCourses = new ListOfCourses();
                myCourses.Courses = courses.ToArray();
                string sourcePath = ConfigurationManager.AppSettings["Courses"];
                Console.WriteLine(File.Exists(sourcePath) ? "File exists." : "File does not exist.");
                XmlSerializer serializer = new XmlSerializer(typeof(ListOfCourses));
                TextWriter writer = new StreamWriter(sourcePath);
                serializer.Serialize(writer, myCourses);
                writer.Close();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public bool LoadLessonsFromCourse()
        {
            try
            {
                if (_courses != null)
                {
                    foreach (Course course in _courses)
                    {
                        switch (course.Name)
                        {
                            case "Signal Theory":
                                course.LoadLessons(ConfigurationManager.AppSettings["SignalTheory"]);
                                break;
                            case "Physic 1":
                                course.LoadLessons(ConfigurationManager.AppSettings["Physic1"]);
                                break;
                            case "Database":
                                course.LoadLessons(ConfigurationManager.AppSettings["Database"]);
                                break;
                        }
                    }
                    return true;
                }
                else
                    return false;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool LoadAllStudents()
        {
            try
            {
                if (_courses != null)
                {
                    foreach (Course course in _courses)
                    {
                        course.LoadStudents();
                    }
                    return true;
                }
                else
                    return false;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public bool LoadStudentsFromCourse()
        {
            try
            {
                if (_courses != null)
                {
                    foreach (Course course in _courses)
                    {
                        foreach (Lesson lesson in course.Lessons)
                        {
                            switch (course.Name)
                            {
                                case "Signal Theory":
                                    lesson.LoadLessStudents(ConfigurationManager.AppSettings["StudentsST"]);
                                    break;
                                case "Physic 1":
                                    lesson.LoadLessStudents(ConfigurationManager.AppSettings["StudentsP1"]);
                                    break;
                                case "Database":
                                    lesson.LoadLessStudents(ConfigurationManager.AppSettings["StudentsDB"]);
                                    break;
                            }
                        }
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void LoadCourses()
        {
            try
            {
                string sourcePath = ConfigurationManager.AppSettings["Courses"];
                Console.WriteLine(File.Exists(sourcePath) ? "File exists." : "File does not exist.");
                XmlSerializer serializer = new XmlSerializer(typeof(ListOfCourses));
                StreamReader reader = new StreamReader(sourcePath);
                ListOfCourses myCourses = new ListOfCourses();
                myCourses = (ListOfCourses)serializer.Deserialize(reader);
                reader.Close();

                if (myCourses != null)
                {
                    for (int i = 0; i < myCourses.Courses.Length; i++)
                    {
                        Course c = myCourses.Courses[i];
                        _courses.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Init()
        {
            LoadCourses();
            LoadAllStudents();
            LoadLessonsFromCourse();
            LoadStudentsFromCourse();
        }
        public List<Student> FollowerStudentsInLessons(DateTime date, string name)
        {
            try
            {
                List<Student> myStudents = new List<Student>();
                var filteredStudents = _courses.Where(x => x.Name == name && x.Edition == date.Year).SingleOrDefault();
                if (filteredStudents != null)
                {
                    filteredStudents.Lessons.ForEach(x =>
                    {
                        myStudents = x.Students;
                    });
                    return myStudents;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public List<Student> AbsentStudentsInLessons(DateTime date, string name)
        {
            try
            {
                foreach (Course course in _courses)
                {
                    if (course.Name == name && course.Edition == date.Year)
                    {
                        foreach (Lesson lesson in course.Lessons)
                        {
                            if (lesson.Date == date)
                            {
                                return course.Students.Except(lesson.Students).ToList();
                            } 
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Lesson> GetLessonsInCourse(string name, int edition)
        {
            try
            {
                var filteredCourses = _courses.Where(x => x.Name == name && x.Edition == edition).SingleOrDefault();
                if (filteredCourses != null)
                {
                    return filteredCourses.Lessons;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public List<Student> GetStudentsInCourse(string name, int edition)
        {
            try
            {
                var filteredCourse = _courses.Where(x => x.Name == name && x.Edition == edition).SingleOrDefault();
                if (filteredCourse != null)
                {
                    return filteredCourse.Students;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public List<Course> GetSubbedCoursesByNumber(string number)
        {
            try
            {
                List<Course> subbedStudentList = new List<Course>();
                foreach (Course course in _courses)
                {
                    foreach (Student student in course.Students)
                    {
                        if (student.Number == number)
                        {
                            subbedStudentList.Add(course);
                            return subbedStudentList;
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Lesson> SummarizeLesson(DateTime date, string name)
        {
            try
            {
                var filteredCourses = _courses.Where(x => x.Name == name && x.Edition == date.Year).SingleOrDefault();
                if (filteredCourses != null)
                {
                    return filteredCourses.Lessons;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        //Media dei presenti alle lezioni ad un singolo corso
        public double AvgFollowOneCourseStudents (string name, int edition)
        {
            try
            {
                double totFollowStudents = 0, totFollowingLesson = 0;
                var filteredCourses = _courses.Where(x => x.Name == name && x.Edition == edition).SingleOrDefault();
                if (filteredCourses != null)
                {
                    filteredCourses.Lessons.ForEach(x =>
                    {
                        totFollowStudents += x.Students.Count();
                    });
                    totFollowingLesson = filteredCourses.Lessons.Count();
                    if (totFollowStudents > 0)
                    {
                        return GetAvg(totFollowStudents,totFollowingLesson);
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        //Percentuale di lezioni seguite di un corso di un studente
        public double PercentageFollowerStudentLesson(string name, int edition, string number)
        {
            try
            {
                double totPresStud = 0;
                double totNumLess = 0;
                var filteredCourses = _courses.Where(x => x.Name == name && x.Edition == edition).SingleOrDefault();
                if (filteredCourses != null)
                {
                    filteredCourses.Lessons.ForEach(x =>
                    {
                        totPresStud += x.Students.Count(x => x.Number == number);
                    });
                    totNumLess = filteredCourses.Lessons.Count();
                    if (totPresStud > 0)
                    {
                        return GetPercentage(totPresStud, totNumLess);
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        //Media degli studenti alle lezioni di tutti i corsi
        public double AvgFollowLessonsStudents()
        {
            try
            {
                double TotFollowLessons = 0, TotLessCourse = 0;
                if (_courses.Count > 0)
                {
                    foreach (Course course in _courses)
                    {
                        TotLessCourse = course.Lessons.Count();
                        course.Lessons.ForEach(x =>
                        {
                            TotFollowLessons += x.Students.Count();
                        });
                    }
                    if (TotLessCourse > 0)
                    {
                        return GetAvg(TotFollowLessons, TotLessCourse);
                    }
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
        //Media degli studenti iscritti ai corsi 
        public double AvgSubbedCourseStudents()
        {
            try
            {
                double TotSubbedStudents = 0, TotNumberCourses = 0;
                TotNumberCourses = _courses.Count();
                foreach (Course course in _courses)
                {
                    TotSubbedStudents += course.Students.Count();
                }
                if (TotNumberCourses > 0)
                    return GetAvg(TotSubbedStudents, TotNumberCourses);
                else
                    return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
