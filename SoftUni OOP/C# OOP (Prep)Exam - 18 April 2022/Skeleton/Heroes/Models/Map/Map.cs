using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = null;
            List<IHero> barbarians = null;

            knights = players.Where(p => p.GetType().Name == nameof(Knight)).ToList();
            barbarians = players.Where(p => p.GetType().Name == nameof(Barbarian)).ToList();

            //foreach (var knight in players)
            //{
            //    if (knight.GetType().Name == nameof(Knight))
            //    {
            //        knights.Add(knight);
            //    }
            //}
            //
            //foreach (var barbarian in barbarians)
            //{
            //    if (barbarian.GetType().Name == nameof(Barbarian))
            //    {
            //        knights.Add(barbarian);
            //    }
            //}

            bool knightsWin = false;
            bool barbariansWin = false;

            while (true)
            {
                if (knights.Any(k => k.IsAlive))
                {
                    barbariansWin = true;
                    break;
                }

                if (barbarians.Any(b => b.Health > 0))
                {
                    knightsWin = true;
                    break;
                }

                barbarians.ForEach(b => b.TakeDamage(knights.Where(k => k.IsAlive == true)
                    .Sum(k => k.Weapon.DoDamage())));

                knights.ForEach(k => k.TakeDamage(barbarians.Where(b => b.IsAlive == true)
                    .Sum(b => b.Weapon.DoDamage())));
                //foreach (var knight in knights.Where(k => k.IsAlive))
                //{
                //    foreach (var barbarian in barbarians)
                //    {
                //        barbarian.TakeDamage(knight.Weapon.DoDamage());
                //    }
                //}
                //
                //foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                //{
                //    foreach (var knight in knights)
                //    {
                //        knight.TakeDamage(barbarian.Weapon.DoDamage());
                //    }
                //}
            }

            if (knightsWin)
            {
                int numberOfDeadKnights = knights.Count(k => k.IsAlive == false);
                return $"The knights took {numberOfDeadKnights} casualties but won the battle.";
            }
            else if (barbariansWin)
            {
                int numberOfDeadBarbarians = barbarians.Count(b => b.IsAlive == false);
                return $"The barbarians took {numberOfDeadBarbarians} casualties but won the battle.";
            }

            return null;
        }
    }
}
