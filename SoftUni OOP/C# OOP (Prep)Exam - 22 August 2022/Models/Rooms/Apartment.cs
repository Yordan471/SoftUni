﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int apartmentBeds = 6;

        public Apartment(int bedCapacity, double pricePerNight = 0) : base(apartmentBeds, pricePerNight)
        {
        }
    }
}
