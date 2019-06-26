using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string TrainerName { get; set; }
        public int NumberOfBadges { get; set; } = 0;
        public List<Pokemon> PokemonCollection { get; set; }


        public Trainer(string name, Pokemon pokemon)
        {
            this.TrainerName = name;
            this.PokemonCollection = new List<Pokemon>();
            this.PokemonCollection.Add(pokemon);

        }
        
    }
}
