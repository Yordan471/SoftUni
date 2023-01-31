namespace Pokemon_Trainer
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
                            break;
                        }
                    }
                }
            }

            string secondCommand = string.Empty;

            while ((secondCommand = Console.ReadLine()) != "End")
            {
                string inputElement = secondCommand;

                foreach (var trainer in listTrainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == inputElement))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);

                        trainer.Pokemons = trainer.Pokemons.FindAll(h => h.Health > 0).ToList();
                    }
                }
            }

            foreach (var trainer in listTrainers.OrderByDescending(t => t.NumberOfBadges))
            {
                trainer.PrintOutput(trainer);
            }
        }
    }
}