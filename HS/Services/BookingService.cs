using System;
using System.Threading.Tasks;
using Hotel.Interfaces;
using HS.Context.Entities;

namespace HS.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<Reservation> _reservations;

        public BookingService(IRepository<Reservation> reservations)
        {
            _reservations = reservations;
        }

        public Reservation Reservate(Client client, DateTime arrivalDate, DateTime departureDate,
            Room selectedRoom)
        {
            var reservation = new Reservation
            {
                ArrivalDate = arrivalDate,
                DepartureDate = departureDate,
                Client = client,
                Room = selectedRoom
            };
            _reservations.Add(reservation);
            return reservation;
        }
    }
}