using System;
using System.Windows.Input;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class NewReservByClientViewModel : ViewModel
    {
        private readonly IBookingService _bookingService;
        
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
        
        private ICommand _createNewReservCommand;
        private readonly ViewModelLocator _locator;

        public ICommand CreateNewReservCommand => _createNewReservCommand
            ??= new RelayCommand(OnCreateNewReservCommandExecuted, CanCreateNewReservCommandExecute);
        
        private bool CanCreateNewReservCommandExecute(object parameter) => true;

        private void OnCreateNewReservCommandExecuted(object parameter)
        {
            _bookingService.Reservate(_locator.MainViewModel.CurrentUser, ArrivalDate, DepartureDate);
        }

        public NewReservByClientViewModel(ViewModelLocator locator, IBookingService bookingService)
        {
            _bookingService = bookingService;
            _locator = locator;
        }
    }
}