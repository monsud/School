namespace School.Model
{
    public class Professor
    {
        private string? _name;
        private string? _surname;
        private string? _degree;
        public Professor () {}

        public string? Name
        {
            get => _name;
            set => _name = value;
        }
        public string? Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public string? Degree
        {
            get => _degree;
            set => _degree = value;
        }

        public override string ToString()
        {
            return " PROFESSOR ==  " + " Name: " + Name + " Surname: " + Surname + " Degree: " + Degree;
        }
    }
}
