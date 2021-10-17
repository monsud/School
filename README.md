# School
An exercise that implement a school with C# and MVC pattern.

We want to create a system for the management of courses. Each course has a name and an integer that indicates the edition. Each course is divided into a certain number of lessons. Each lesson has a description, a date, a start time, a duration, a teacher and an assigned classroom.
The teachers have a name, a surname and a qualification.

Each classroom has a capacity, a name and a list of resources (eg Video Projector, PC, Notebook, Tablet, IWB, etc.).

Each course has a certain number of participating students, enrolled in that specific edition. Each student has a name, a surname and a freshman. For each lesson it is necessary to keep track of those present.

The system must allow:

Add course
Add lessons to a course
Add students to a course
Mark those absent from a lesson

The system must allow the following screen printouts:

Course List DONE!
List of lessons of a course
List of students enrolled in a course
Summary sheet of a lesson
List of those present at a lesson

Average attendance at a lesson
Average attendance at a course (average between lessons)
Percentage of attendance of a student in a course (course input, freshman)
List of courses to which a student is enrolled (matriculation input)
Average of students enrolled in courses
