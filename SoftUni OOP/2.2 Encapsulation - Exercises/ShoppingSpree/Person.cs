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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
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

        public List<Product> BagOfProducts => bagOfProducts;

        public string AddProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                return $"{this.name} can't afford {product}";
            }

            this.bagOfProducts.Add(product);
            this.Money -= product.Cost;
            return $"{this.name} bought {product}";
        }

        public override string ToString()
        {
            string allProducts = bagOfProducts.Any()
                ? string.Join(", ", bagOfProducts)
                : "Nothing bought";

            return $"{this.Name} - {allProducts}".ToString().Trim();
        }
    }
}
