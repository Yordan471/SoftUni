using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            this.Name = name;
            this.StorageCapacity = storageCapacity;
            this.Shoes = new List<Shoe>();
        }

        public string Name { get; set; }

        public int StorageCapacity { get; set; }

        public List<Shoe> Shoes { get; private set; }

        public int Count
        {
            get
            {
                return this.Shoes.Count;
            }
        }

        string AddShoe(Shoe shoe)
        {
            if (this.Count == this.StorageCapacity)
            {
                return "No more space in the storage room."; 
            }

            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        int RemoveShoes(string material)
        {
            int countRemovedShoes = 0;

            while (Shoes.Any(s => s.Material == material))
            {
                Shoes.Remove(Shoes.First());
                countRemovedShoes++;
            }

            return countRemovedShoes;
        }

        List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> specificType = new();

            while (Shoes.Any(s => s.Type.ToLower() == type.ToLower()))
            {
                specificType.Add(Shoes.First());
            }

            return specificType;
        }

        Shoe GetShoeBySize(double size)
        {
            Shoe shoeBySize = new();

            if (Shoes.Any(s => s.Size == size))
            {
                shoeBySize = Shoes.First(s => s.Size == size);
            }

            return shoeBySize;
        }

        string StockList(double size, string type)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (Shoes.Any(s => s.Size == size && s.Type == type))
            {
                stringBuilder.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (var sho in Shoes)
                {
                    stringBuilder.AppendLine(sho.ToString());
                }

                return stringBuilder.ToString();
            }

            return "No matches found!";
        }
    }
}
