using System;

namespace Zoo
{
    public class Gorilla : Mammal
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Gorilla(string name) : base(name)
        {
        }
    }
}
