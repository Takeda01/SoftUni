using System;
using System.Text;

namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (age < 0)
                {
                    this.age = 0;
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();


        }
    }
}
