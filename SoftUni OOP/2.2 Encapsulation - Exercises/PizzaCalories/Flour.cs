using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Flour
    {
        private const string white = "White";
        private const string wholegrain = "Wholegrain";
        private const string crispy = "Crispy";
        private const string chewy = "Chewy";
        private const string homemade = "Homemade";
        private const double minGrams = 1;
        private const double maxGrams = 200;

        public string White { get => white; }
        public string Wholegrain { get => wholegrain; }

        public string Crispy { get => crispy; }

        public string Chewy { get => chewy; }

        public string Homemade { get => homemade; }

        public double MinGrams { get => minGrams; }

        public double MaxGrams { get => maxGrams; }

    }
}
