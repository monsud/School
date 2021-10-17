using System;
using System.Collections.Generic;
using System.Text;

namespace School.Model
{
    public class Room
    {
        private string? _name;
        private TypeRes? _resource;
        private int? _capacity;
        public Room() {}

        public enum TypeRes
        {
            VideProjector,
            PC,
            Notebook,
            Tablet,
            LIM
        }
        public string? Name
        {
            get => _name;
            set => _name = value;
        }
        public int? Capacity
        {
            get => _capacity;
            set => _capacity = value;
        }

        public override string ToString()
        {
            return " ROOM ==  " + " Name: " + Name + " Capacity: " + Capacity;
        }
    }
}
