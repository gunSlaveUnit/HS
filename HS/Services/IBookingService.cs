using System;
using System.Threading.Tasks;
using Hotel.Context.Entities;

namespace HS.Services
{
    public interface IBookingService
    {
        public Task<Reservation> Reservate(Client client, DateTime arrivalDate, DateTime departureDate);
    }
}