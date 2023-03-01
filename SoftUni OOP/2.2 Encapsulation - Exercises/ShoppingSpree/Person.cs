using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;
        private List<Person> persons;
        

        public Person() { }

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> BagOfProducts => bagOfProducts;

        public bool AddProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.bagOfProducts.Add(product);
                this.Money -= product.Cost;
                return true;
            }

            return false;
        }

        public Person GetPerson(string name)
        {
            return persons.FirstOrDefault(p => p.Name == name);
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            if (persons.Count > 0)
            {
                foreach (var person in persons)
                {
                    sb.AppendLine($"{person.Name} - {string.Join(", ", this.bagOfProducts)}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
