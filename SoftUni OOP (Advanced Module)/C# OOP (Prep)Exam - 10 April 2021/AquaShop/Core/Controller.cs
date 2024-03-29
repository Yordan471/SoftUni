﻿using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;

            if (aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(aquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else if(decorationType == nameof(Plant))
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType == nameof(FreshwaterFish))
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == nameof(SaltwaterFish))
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }

            IAquarium aquarium = aquariums
                .FirstOrDefault(a => a.Name == aquariumName);
            string aquariumType = aquarium.GetType().Name;

            if (fishType == nameof(FreshwaterFish) && aquariumType == nameof(FreshwaterAquarium))
            {
                aquarium.AddFish(fish);

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if (fishType == nameof(SaltwaterFish) && aquariumType == nameof(SaltwaterAquarium))
            {
                aquarium.AddFish(fish);

                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else
            {
                return string.Format(OutputMessages.UnsuitableWater);
            }
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal value = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            aquariums.FirstOrDefault(a => a.Name == aquariumName).Feed();
            int fishCount = aquariums.FirstOrDefault(a => a.Name == aquariumName).Fish.Count();

            return string.Format(OutputMessages.FishFed, fishCount);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.Models
                .FirstOrDefault(d => d.GetType().Name == decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            aquariums
                .FirstOrDefault(a => a.Name == aquariumName)
                .AddDecoration(decoration);

            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
