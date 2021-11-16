using Hotel.Context.Entities;
using Hotel.Interfaces;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class ReservationsViewModel : ViewModel
    {
        public ReservationsViewModel(IRepository<Reservation> reservationsRepository)
        {
            
        }
    }
}