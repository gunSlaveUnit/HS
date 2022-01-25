﻿using System;
using System.Threading.Tasks;
using HS.Context.Entities;

namespace HS.Services
{
    public interface IBookingService
    {
        public Reservation Reservate(Client client, DateTime arrivalDate, DateTime departureDate,
            Room selectedRoom, int cost, bool isActive);
    }
}