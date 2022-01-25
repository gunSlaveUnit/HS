using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            Room selectedRoom, int cost, bool isActive)
        {
            var reservation = new Reservation
            {
                ArrivalDate = arrivalDate,
                DepartureDate = departureDate,
                Client = client,
                Room = selectedRoom,
                Cost = cost,
                Active = isActive
            };
            var crossReservation = new ObservableCollection<Reservation>(_reservations.All.Where(
                r =>
                    (r.ArrivalDate <= arrivalDate && arrivalDate <= r.DepartureDate
                     || r.ArrivalDate <= departureDate && departureDate <= r.DepartureDate)
                    && r.RoomId == selectedRoom.Id)).FirstOrDefault();
            if (crossReservation is null) return _reservations.Add(reservation);
            return null;
        }
    }
}