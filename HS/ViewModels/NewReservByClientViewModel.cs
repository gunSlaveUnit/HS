using System;
using System.Windows.Input;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class NewReservByClientViewModel : ViewModel
    {
        private readonly IBookingService _bookingService;

        private ICommand _createNewReservCommand;
        private readonly ViewModelLocator _locator;
        private readonly Client _currentClient;
        private Room _selectedRoom;

        public Room SelectedRoom
        {
            get => _selectedRoom;
            set => Set(ref _selectedRoom, value);
        }

        private DateTime _arrivalDate;

        public DateTime ArrivalDate
        {
            get => _arrivalDate;
            set => Set(ref _arrivalDate, value);
        }
        
        private DateTime _departureDate;

        public DateTime DepartureDate
        {
            get => _departureDate;
            set => Set(ref _departureDate, value);
        }
        
        private string _periodsAmount;

        public string PeriodsAmount
        {
            get => _periodsAmount;
            set => Set(ref _periodsAmount, value);
        }

        private bool _isHours;

        public bool IsHours
        {
            get => _isHours;
            set => Set(ref _isHours, value);
        }
        
        private bool _isDays;

        public bool IsDays
        {
            get => _isDays;
            set => Set(ref _isDays, value);
        }

        public ICommand CreateNewReservCommand => _createNewReservCommand
            ??= new RelayCommand(OnCreateNewReservCommandExecuted, CanCreateNewReservCommandExecute);
        
        private bool CanCreateNewReservCommandExecute(object parameter) => true;

        private void OnCreateNewReservCommandExecuted(object parameter)
        {
            //_bookingService.Reservate(_locator.MainViewModel.CurrentUser, ArrivalDate, DepartureDate);
        }

        public NewReservByClientViewModel(ViewModelLocator locator, IBookingService bookingService)
        {
            _bookingService = bookingService;
            _locator = locator;
            _currentClient = _locator.MainViewModel.CurrentUser;
        }
    }
}