using AnimalCentre.Core.Contracts;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre : IAnimalCentre
    {
        private IHotel hotel;
        private IProcedure procedure;

        private Chip chip;
        private DentalCare dentalcare;
        private Fitness fitness;
        private NailTrim nailtrim;
        private Play play;
        private Vaccinate vaccinate;
        public AnimalCentre(IHotel hotel,
            IProcedure procedure,
            Chip chip,
            DentalCare dentalcare,
            Fitness fitness,
            NailTrim nailtrim,
           Play play,
           Vaccinate vaccinate)
        {
            this.hotel = hotel;
            this.procedure = procedure;
            chip = new Chip();
            dentalcare = new DentalCare();
            fitness = new Fitness();
            nailtrim = new NailTrim();
            play = new Play();
            vaccinate = new Vaccinate();
        }
        public string Adopt(string animalName, string owner)
        {
            CheckIfAnimalExists(this.hotel.Animals[animalName]);

            var animalToAdopt = this.hotel.Animals[animalName];

            this.hotel.Adopt(animalName, owner);

            if (animalToAdopt.IsChipped == true)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string Chip(string name, int procedureTime)
        {
            CheckIfAnimalExists(this.hotel.Animals[name]);

            var animalToChip = this.hotel.Animals[name];

            this.chip.DoService(animalToChip, procedureTime);

            return $"{animalToChip.Name} had chip procedure";
        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckIfAnimalExists(this.hotel.Animals[name]);

            var animalToDoFitness = this.hotel.Animals[name];

            this.dentalcare.DoService(animalToDoFitness, procedureTime);

            return $"{animalToDoFitness.Name} had dental care procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            CheckIfAnimalExists(this.hotel.Animals[name]);

            var animalToDoFitness = this.hotel.Animals[name];

            this.fitness.DoService(animalToDoFitness, procedureTime);

            return $"{animalToDoFitness.Name} had fitness procedure";
        }

        public string History(string type)
        {
            StringBuilder sb = new StringBuilder();

            var currentProcedure = (IProcedure)type.GetType();

            foreach (var animal in currentProcedure.ProcedureHistory)
            {
                sb.AppendLine(type);
                sb.AppendLine($"   Animal type: {animal.GetType().Name} - { animal.Name} -Happiness: { animal.Happiness} -Energy: { animal.Energy}");
            }

            return sb.ToString().TrimEnd();
        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckIfAnimalExists(this.hotel.Animals[name]);

            var animalToDoNailTrim = this.hotel.Animals[name];

            this.nailtrim.DoService(animalToDoNailTrim, procedureTime);

            return $"{animalToDoNailTrim.Name} had nail trim procedure";
        }

        public string Play(string name, int procedureTime)
        {
            CheckIfAnimalExists(this.hotel.Animals[name]);

            var animalToDoFitness = this.hotel.Animals[name];

            this.play.DoService(animalToDoFitness, procedureTime);

            return $"{name} was playing for {procedureTime} hours";

        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {

            IAnimal animal = null;

            if (type == "Cat")
            {
                animal = new Cat(name, energy, happiness, procedureTime);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, energy, happiness, procedureTime);
            }
            else if (type == "Lion")
            {
                animal = new Lion(name, energy, happiness, procedureTime);
            }
            else if (type == "Pig")
            {
                animal = new Pig(name, energy, happiness, procedureTime);
            }

            //CheckIfAnimalExists(animal);
            //I will not check for invalid happiness or energy 

            this.hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";

        }

        public string Vaccinate(string name, int procedureTime)
        {
            CheckIfAnimalExists(this.hotel.Animals[name]);

            var animalToVaccinate = this.hotel.Animals[name];

            this.vaccinate.DoService(animalToVaccinate, procedureTime);

            return $"{animalToVaccinate.Name} had vaccination procedure";
        }

        private void CheckIfAnimalExists(IAnimal animal)
        {
            if (hotel.Animals.ContainsKey(animal.Name) == false)
            {
                throw new ArgumentException($"Animal {animal.Name} does not exist");
            }
        }


    }
}
