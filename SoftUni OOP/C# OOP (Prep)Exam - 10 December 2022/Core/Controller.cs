using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;
        
        public Controller()
        {
            this.booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = this.booths.Models.Count + 1;
            Booth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);
            return $"Added booth number {boothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }
            else if (size != "Small" && size != "Middle" && size != "Large")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }
            else if (booths.Models.Any(b => b.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size)))
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            ICocktail cocktail = null;

            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.CocktailMenu.AddModel(cocktail);

            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != typeof(Gingerbread).Name && delicacyTypeName != typeof(Stolen).Name)
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }
            else if (this.booths.Models.Any(b => b.DelicacyMenu.Models.Any(d => d.Name == delicacyName)))
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            IDelicacy delicacy = null;

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.DelicacyMenu.AddModel(delicacy);

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId ==  boothId);
            return booth.ToString().Trim();
            //StringBuilder sb = new StringBuilder();
            //
            //sb.AppendLine($"Booth {boothId} is now available!");
            //sb.AppendLine($"Capacity: {booth.Capacity}");
            //sb.AppendLine($"Turnover: {booth.Turnover: f2} lv");
            //sb.AppendLine($"-Cocktail menu:");
            //
            //foreach (var cocktail in booth.CocktailMenu.Models)
            //{
            //    sb.AppendLine($"{cocktail}");
            //}
            //
            //sb.AppendLine($"-Delicacy menu:");
            //
            //foreach (var delicacy in booth.DelicacyMenu.Models)
            //{
            //    sb.AppendLine($"{delicacy}");
            //}
            //
            //return sb.ToString().Trim();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId ==  boothId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");

            booth.Charge();
            booth.ChangeStatus();
           
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }
            else
            {
                booth.ChangeStatus();
                return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";
            }
        }

        public string TryOrder(int boothId, string order)
        {
            string[] boothInfo = order
                .Split("/", StringSplitOptions.RemoveEmptyEntries);
            bool isCocktail = false;

            string itemTypeName = boothInfo[0];

            if (itemTypeName != nameof(Hibernation) && 
                itemTypeName != nameof(MulledWine) &&
                itemTypeName != nameof(Stolen) &&
                itemTypeName != nameof(Gingerbread))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            string itemName = boothInfo[1];
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName) &&
                !booth.DelicacyMenu.Models.Any(d => d.Name == itemName))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            int countOrderedPieces = int.Parse(boothInfo[2]);
            
            if (itemTypeName == nameof(Hibernation) || 
                itemTypeName ==  nameof(MulledWine))
            {
                isCocktail = true;
            }

            if (isCocktail)
            {
                string size = boothInfo[3];

                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.GetType().Name == itemTypeName &&
                c.Name == itemName && c.Size == size);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * countOrderedPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOrderedPieces, itemName);
            }

            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.GetType().Name == itemTypeName && d.Name == itemName);

            if (delicacy == null)
            {
                return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
            }

            booth.UpdateCurrentBill(delicacy.Price * countOrderedPieces);
            return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOrderedPieces, itemName);
        }
    }
}
