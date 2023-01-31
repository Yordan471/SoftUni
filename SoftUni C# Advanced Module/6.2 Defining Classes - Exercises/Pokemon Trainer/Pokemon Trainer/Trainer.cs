using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer()
        {
            Name = "";
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }

        public Trainer(string name, List<Pokemon> pokemons)
        {
            Name = name;

            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get; set; }


        public void PrintOutput(Trainer trainer)
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
        }
    }
}
