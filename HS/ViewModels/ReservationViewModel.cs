using Hotel.Context.Entities;
using Hotel.Interfaces;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class ReservationViewModel : ViewModel
    {
        private IRepository<Reservation> _reservationsRepository;

        public ReservationViewModel(IRepository<Reservation> reservationsRepository)
        {
            _reservationsRepository = reservationsRepository;
        }
    }
}