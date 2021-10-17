using System;

namespace School.Model
{
    public class Student : IEquatable<Student>
    {
        private string? _name;
        private string? _surname;
        private string? _number;
        public Student() {}

        public string? Name
        {
            get => _name;
            set => _name = value;
        }
        public string ?Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public string? Number
        {
            get => _number;
            set => _number = value;
        }
        public bool Equals(Student student)
        {
            if (student is null)
                return false;
            return this.Number == student.Number && this.Name == student.Name && this.Surname == student.Surname;
        }
        public override bool Equals(object obj) => Equals(obj as Student);
        public override int GetHashCode() => (Number, Name, Surname).GetHashCode();


        public override string ToString()
        {
            return " STUDENT ==  " + " Name: " + Name + " Surname: " + Surname + " Number: " + Number;
        }
    }
}
