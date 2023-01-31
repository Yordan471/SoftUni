using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer()
        {
            //Name = "";
            this.NumberOfBadges = 0;
            this.ACollectionOfPokemon = new List<Pokemon>();
        }

        public Trainer(string name, List<Pokemon> pokemons)
        {
            this.Name = name;

            this.ACollectionOfPokemon = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> ACollectionOfPokemon { get; set; }


        public void PrintOutput(Trainer trainer)
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.ACollectionOfPokemon.Count}");
        }
    }
}
