using System;
namespace Zoo
{
    public class Mammal : Animal
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Mammal(string name) : base(name)
        {
        }
    }
}
