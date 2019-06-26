using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> alltrainers = new List<Trainer>();
            List<string> trainerNames = new List<string>();

            while (true)
            {
                string[] trainerAndPokemonInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (trainerAndPokemonInfo[0] == "Tournament")
                {
                    break;
                }
                if (trainerAndPokemonInfo.Length != 4)
                {
                    continue;
                }

                string trainerName = trainerAndPokemonInfo[0];
                string pokemonName = trainerAndPokemonInfo[1];
                string pokemonElement = trainerAndPokemonInfo[2];
                int pokemonHealth = int.Parse(trainerAndPokemonInfo[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainerNames.Contains(trainerName))
                {
                    trainerNames.Add(trainerName);
                    Trainer trainer = new Trainer(trainerName, pokemon);
                    alltrainers.Add(trainer);
                }
                else if (trainerNames.Contains(trainerName))
                {
                    Trainer trainerToAddPokemonTo = alltrainers.Where(x => x.TrainerName == trainerName).ToList()[0];
                    trainerToAddPokemonTo.PokemonCollection.Add(pokemon);
                }

            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                foreach (var trainer in alltrainers)
                {
                    int countPokemonWithGivenElement = 0;

                    foreach (var pokemon in trainer.PokemonCollection)
                    {
                        if (pokemon.Element.Contains(command))
                        {
                            trainer.NumberOfBadges += 1;
                            countPokemonWithGivenElement++;

                            break;
                        }
                        
                    }
                    if (countPokemonWithGivenElement==0)
                    {
                        foreach (var currentPokemon in trainer.PokemonCollection.ToList())
                        {
                            currentPokemon.Health -= 10;
                            if (currentPokemon.Health <= 0)
                            {
                                trainer.PokemonCollection.Remove(currentPokemon);
                            }
                        }
                    }
                }
            }
            foreach (var trainer in alltrainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.TrainerName} {trainer.NumberOfBadges} {trainer.PokemonCollection.Where(x => x.Health > 0).Count()}");
            }
        }
    }
}
