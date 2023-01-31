﻿namespace Pokemon_Trainer
{
    public class StartUp
    {
        public static void Main()
        {
            string command = string.Empty;
            
            List<Trainer> listTrainers = new List<Trainer>();

            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] trainerInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = trainerInfo[0];
                string pokemonName = trainerInfo[1];
                string pokemonElement = trainerInfo[2];
                int pokemonHealth = int.Parse(trainerInfo[3]);
                
                Pokemon pokemon = new(pokemonName, pokemonElement, pokemonHealth);
                Trainer currTrainer = new();

                if (!listTrainers.Any(t => t.Name == trainerName))
                {
                    currTrainer.Name = trainerName;
                    currTrainer.Pokemons.Add(pokemon);
                    listTrainers.Add(currTrainer);
                }
                else
                {
                    foreach (var trainer in listTrainers)
                    {
                        if (trainer.Name == trainerName)
                        {
                            trainer.Pokemons.Add(pokemon);
                        }
                    }
                }
            }


        }
    }
}