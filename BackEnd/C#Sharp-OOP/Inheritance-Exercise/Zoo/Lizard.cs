using System;

namespace Zoo
{
    public class Lizard : Reptile
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Lizard(string name) : base(name)
        {
        }
    }
}
