using System;
using System.Threading.Tasks;
using Hotel.Context.Entities;
using Hotel.Interfaces;

namespace HS.Services
{
    public class BookingService
    {
        private readonly IRepository<Reservation> _reservations;

        public BookingService(IRepository<Reservation> reservations)
        {
            _reservations = reservations;
        }

        public async Task<Reservation> Reservate(Client client, DateTime arrivalDate, DateTime departureDate)
        {
            var reservation = new Reservation
            {
                ArrivalDate = arrivalDate,
                DepartureDate = departureDate,
                Client = client
            };
            await _reservations.AddAsync(reservation);
            return reservation;
        }
    }
}