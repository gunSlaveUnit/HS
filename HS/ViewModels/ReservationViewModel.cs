using System.Windows;
using System.Windows.Input;
using Hotel.Context.Entities;
using Hotel.Interfaces;
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
        
        private ICommand _makeReservationCommand;
        public ICommand MakeReservationCommand => _makeReservationCommand
            ??= new RelayCommand(OnMakeReservationCommandExecuted, CanMakeReservationCommandExecute);
        
        private bool CanMakeReservationCommandExecute(object parameter) => true;

        private void OnMakeReservationCommandExecuted(object parameter)
        {
            //TODO: It works, but it is not good in MVVM architecture
            var newReservationByClientWindow = new NewReservationByClient();
            newReservationByClientWindow.Owner = Application.Current.MainWindow;
            newReservationByClientWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newReservationByClientWindow.ShowDialog();
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