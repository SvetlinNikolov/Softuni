using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> collectionOfHeroes;

        public HeroRepository()
        {
            collectionOfHeroes = new List<Hero>();
        }

        public int Count => collectionOfHeroes.Count();

        public void Add(Hero hero)
        {
            collectionOfHeroes.Add(hero);
        }

        public void Remove(string name)
        {
            var heroToRemove = collectionOfHeroes.FirstOrDefault(x => x.Name == name);
            collectionOfHeroes.Remove(heroToRemove);
        }
        public Hero GetHeroWithHighestStrength()
        {
            var heroWithHighestStrength = collectionOfHeroes
                .OrderByDescending(x => x.Item.Strength)
                .FirstOrDefault();

            return heroWithHighestStrength;
        }
        public Hero GetHeroWithHighestAbility()
        {
            var heroWithHighestAbility = collectionOfHeroes
                .OrderByDescending(x => x.Item.Ability)
                .FirstOrDefault();

            return heroWithHighestAbility;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            var heroWithHighestIntelligence = collectionOfHeroes
                .OrderByDescending(x => x.Item.Intelligence)
                .FirstOrDefault();

            return heroWithHighestIntelligence;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in collectionOfHeroes)
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString();
        }

    }
}
