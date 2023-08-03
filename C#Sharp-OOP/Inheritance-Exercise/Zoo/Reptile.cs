using System;


namespace Zoo
{
    public class Reptile : Animal
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Reptile(string name) : base(name)
        {
        }
    }
}
