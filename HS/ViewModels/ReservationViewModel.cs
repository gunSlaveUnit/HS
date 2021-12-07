using System.Windows;
using System.Windows.Input;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;
using HS.Views.Windows.Creation;

namespace HS.ViewModels
{
    public class ReservationViewModel : ViewModel
    {
        private IRepository<Reservation> _reservationsRepository;
        private IBookingService _bookingService;
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
            _bookingService = new BookingService(reservationsRepository);
            CurrentUser = _locator.MainViewModel.CurrentUser;
            _reservationsRepository = reservationsRepository;
        }
    }
}