using Hotel.Context.Entities;
using Hotel.Interfaces;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class ReservationViewModel : ViewModel
    {
        private IRepository<Reservation> _reservationsRepository;
        private readonly ViewModelLocator _locator;
        
        private Client _currentUser;

        public Client CurrentUser
        {
            get => _currentUser;
            set => Set(ref _currentUser, value);
        }

        public ReservationViewModel(ViewModelLocator locator,
            IRepository<Reservation> reservationsRepository)
        {
            _locator = locator;
            CurrentUser = _locator.MainViewModel.CurrentUser;
            _reservationsRepository = reservationsRepository;
        }
    }
}