using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                this.name = value;
            }
        }

        public virtual int Age
        {
            get => age;

            protected set
            {
                if (this.age > 0)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();

            stringBuilder.Append($"Name: {this.name}, Age: {this.age}");

            return stringBuilder.ToString().Trim();
        }
    }
}
