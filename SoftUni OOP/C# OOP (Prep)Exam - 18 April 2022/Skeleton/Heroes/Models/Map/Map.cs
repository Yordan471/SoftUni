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

            knights = players.Where(p => p.GetType().Name == nameof(Knight) && p.Weapon != null).ToList();
            barbarians = players.Where(p => p.GetType().Name == nameof(Barbarian) && p.Weapon != null).ToList();

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
                if (knights.All(k => k.IsAlive == false))
                {
                    barbariansWin = true;
                    break;
                }

                if (barbarians.All(b => b.IsAlive == false))
                {
                    knightsWin = true;
                    break;
                }

                //List<IHero> aliveBarbarians = barbarians.Where(b => b.IsAlive).ToList();
                //aliveBarbarians.ForEach(b => b.TakeDamage(knights.Where(k => k.IsAlive == true)
                //    .Sum(k => k.Weapon.DoDamage())));

                //List<IHero> aliveKnights = knights.Where(k => k.IsAlive).ToList();
                //aliveKnights.ForEach(k => k.TakeDamage(barbarians.Where(b => b.IsAlive == true)
                //    .Sum(b => b.Weapon.DoDamage())));

                //barbarians = aliveBarbarians;
                //knights = aliveKnights;

                foreach (var barbarian in barbarians.Where(b => b.IsAlive))
                {
                    barbarian.TakeDamage(knights.Where(k => k.IsAlive)
                       .Sum(k => k.Weapon.DoDamage()));
                }
                            
                foreach (var knight in knights.Where(k => k.IsAlive))
                {
                    knight.TakeDamage(barbarians.Where(b => b.IsAlive == true)
                        .Sum(b => b.Weapon.DoDamage()));
                }
                
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
