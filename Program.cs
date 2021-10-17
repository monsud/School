using System;
using System.Collections.Generic;
using System.Globalization;
using School.Model;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            CSchool mySchool = new CSchool();
            mySchool.Init();

            List<Lesson> list1 = mySchool.GetLessonsInCourse("Signal Theory", 2020);
            List<Student> list2 = mySchool.GetStudentsInCourse("Signal Theory", 2020);
            List<Course> list3 = mySchool.GetSubbedCoursesByNumber("N4959");
            List<Student> list4 = mySchool.FollowerStudentsInLessons(DateTime.Parse("25/10/2020", CultureInfo.CurrentCulture), "Signal Theory");
            List<Student> list5 = mySchool.AbsentStudentsInLessons(DateTime.Parse("25/10/2020", CultureInfo.CurrentCulture), "Signal Theory");
            List<Lesson> list6 = mySchool.SummarizeLesson(DateTime.Parse("25/10/2020", CultureInfo.CurrentCulture), "Signal Theory");
            double result2 = mySchool.AvgFollowOneCourseStudents("Signal Theory", 2020);
            double result3 = mySchool.PercentageFollowerStudentLesson("Signal Theory", 2020, "N4959");
            double result4 = mySchool.AvgFollowLessonsStudents();
            double result5 = mySchool.AvgSubbedCourseStudents();
        }
    }
}
