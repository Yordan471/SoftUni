﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Abstract_Classes;
using WildFarm.Models.Foods;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Classes
{
    public class Tiger : Feline
    {
        private const double TigerWeight = 1.0;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightModifier
        {
            get => TigerWeight;
        }

        public override IReadOnlyCollection<Type> SpecificFoods
        {
            get => new HashSet<Type>() { typeof(Meat) };
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
