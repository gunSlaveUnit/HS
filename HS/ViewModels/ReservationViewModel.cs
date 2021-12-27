using System.Linq;
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
        private string _statusActiveMessage;

        public string StatusActiveMessage
        {
            get => _statusActiveMessage;
            set => Set(ref _statusActiveMessage, value);
        }
        
        private IRepository<Reservation> _reservationsRepository;
        private IBookingService _bookingService;
        private readonly ViewModelLocator _locator;
        
        private Client _currentUser;

        public Client CurrentUser
        {
            get => _currentUser;
            set => Set(ref _currentUser, value);
        }
        
        private Reservation _currentReservation;

        public Reservation CurrentReservation
        {
            get => _currentReservation;
            set => Set(ref _currentReservation, value);
        }

        public ReservationViewModel(ViewModelLocator locator,
            IRepository<Reservation> reservationsRepository)
        {
            _locator = locator;
            _bookingService = new BookingService(reservationsRepository);
            CurrentUser = _locator.MainViewModel.CurrentUser;
            CurrentReservation = CurrentUser.Reservations.FirstOrDefault();
            if (CurrentReservation is not null)
            {
                if (CurrentReservation.Active ) StatusActiveMessage = "Active";
                else StatusActiveMessage = "Not active";
            }
            _reservationsRepository = reservationsRepository;
        }
    }
}