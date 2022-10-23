using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string information = Console.ReadLine();

            List<Box> boxes = new List<Box>();

            while (true)
            {
                if (information == "end")
                {
                    break;
                }

                string[] informationToArray = information
                    .Split()
                    .ToArray();

                string serialNumber = informationToArray[0];
                string itemName = informationToArray[1];
                int itemQuantity = int.Parse(informationToArray[2]);
                decimal itemPrice = decimal.Parse(informationToArray[3]);

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = new Item()
                    {
                        Name = itemName,
                        Price = itemPrice
                    },
                    ItemQuantity = itemQuantity,
                };

                information = Console.ReadLine();

                boxes.Add(box);
            }

            List<Box> orderBoxes = boxes.OrderByDescending(box => box.PriceForABox).ToList();

            foreach (Box box in orderBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox:f2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    class Box
    {
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public decimal PriceForABox 
        {
            get
            {
                return this.ItemQuantity * this.Item.Price;
            }
        }
    }
}
