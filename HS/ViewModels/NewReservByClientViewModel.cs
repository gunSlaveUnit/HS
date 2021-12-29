﻿using System;
using System.Windows.Input;
using System.Windows.Media;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class NewReservByClientViewModel : ViewModel
    {
        private string _message;

        public string Message
        {
            get => _message;
            set => Set(ref _message, value);
        }
        
        private SolidColorBrush _messageColor;

        public SolidColorBrush MessageColor
        {
            get => _messageColor;
            set => Set(ref _messageColor, value);
        }
        
        private readonly IBookingService _bookingService;

        private ICommand _createNewReservCommand;
        private readonly ViewModelLocator _locator;
        private Client _currentClient;

        public Client CurrentClient
        {
            get => _currentClient;
            set => Set(ref _currentClient, value);
        }
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

        private int _cost;

        public int Cost
        {
            get => _cost;
            set => Set(ref _cost, value);
        }

        public ICommand CreateNewReservCommand => _createNewReservCommand
            ??= new RelayCommand(OnCreateNewReservCommandExecuted, CanCreateNewReservCommandExecute);
        
        private bool CanCreateNewReservCommandExecute(object parameter) => true;

        private void OnCreateNewReservCommandExecuted(object parameter)
        {
            var item = _bookingService.Reservate(_locator.MainViewModel.CurrentUser, 
                ArrivalDate, DepartureDate, SelectedRoom, Cost, false);
            if (item is not null)
            {
                Message = "Успешно забронировано. Можете закрыть это окно";
                MessageColor = new SolidColorBrush(Colors.Green);
            }
            else
            {
                Message = "Попробуйте еще раз. Возможно, выбранная комната занята на это время";
                MessageColor = new SolidColorBrush(Colors.Red);
            }
        }

        public NewReservByClientViewModel(ViewModelLocator locator, IBookingService bookingService)
        {
            _bookingService = bookingService;
            _locator = locator;
        }
    }
}