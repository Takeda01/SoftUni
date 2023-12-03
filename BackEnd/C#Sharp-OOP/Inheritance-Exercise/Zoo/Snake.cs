using System;

namespace Zoo
{
    public class Snake : Reptile
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Snake(string name) : base(name)
        {
        }
    }
}
