using System;

namespace Zoo
{
    public class Bear : Mammal
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Bear(string name) : base(name)
        {
        }
    }
}
