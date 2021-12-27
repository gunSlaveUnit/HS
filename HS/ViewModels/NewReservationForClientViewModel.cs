using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class NewReservationForClientViewModel : ViewModel
    {
        private Client _selectedClient;

        public Client SelectedClient
        {
            get => _selectedClient;
            set => Set(ref _selectedClient, value);
        }
        
        private List<Client> _clients;

        public List<Client> Clients
        {
            get => _clients;
            set => Set(ref _clients, value);
        }
        
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
        private readonly IRepository<Client> _clientsRepository;

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
            var item = _bookingService.Reservate(SelectedClient, 
                ArrivalDate, DepartureDate, SelectedRoom, Cost, false);
            if (item is not null)
            {
                Message = "Reservation was created successfully. Close this window";
                MessageColor = new SolidColorBrush(Colors.Green);
            }
            else
            {
                Message = "Try again. The selected room may be occupied at the time of your booking";
                MessageColor = new SolidColorBrush(Colors.Green);
            }
        }

        public NewReservationForClientViewModel(ViewModelLocator locator, IBookingService bookingService,
            IRepository<Client> clientsRepository)
        {
            _bookingService = bookingService;
            _locator = locator;
            _clientsRepository = clientsRepository;

            Clients = _clientsRepository.All.ToList();
        }
    }
}