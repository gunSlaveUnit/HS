using System.Collections.Generic;
using System.Linq;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class ReservationsViewModel : ViewModel
    {
        private IRepository<Reservation> _reservationsRepository;
        private List<Reservation> _reservations;

        public List<Reservation> Reservations
        {
            get => _reservations;
            set => Set(ref _reservations, value);
        }

        public ReservationsViewModel(IRepository<Reservation> reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
            Reservations = _reservationsRepository.All.ToList();
        }
    }
}