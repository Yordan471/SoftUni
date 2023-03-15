using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private readonly IRepository<IDelicacy> delicacies;
        private readonly IRepository<ICocktail> cocktails;
        private double currentBill = 0;
        private double turnover = 0;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;

            this.delicacies = new DelicacyRepository();
            this.cocktails = new CocktailRepository();

            this.currentBill = 0;
            this.turnover = 0;
        }

        public int BoothId { get => boothId; private set => boothId = value; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }

                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacies;

        public IRepository<ICocktail> CocktailMenu => this.cocktails;

        public double CurrentBill
        {
            get => this.currentBill;
        }

        public double Turnover
        {
            get => turnover;
        }

        public bool IsReserved { get; private set; }


        public void ChangeStatus()
        {
            if (IsReserved)
            {
                IsReserved = false;
                return;
            }

            IsReserved = true;
        }

        public void Charge()
        {
            turnover += currentBill;
            currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            currentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {boothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");

            foreach (var cocktail in this.CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }

            sb.AppendLine("-Delicacy menu:");

            foreach (var delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }

            return sb.ToString().Trim();
        }
    }
}
