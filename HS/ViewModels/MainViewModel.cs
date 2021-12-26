using System;
using System.Linq;
using System.Windows.Input;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private DateTime _date;

        public DateTime Date
        {
            get => _date;
            set => Set(ref _date, value);
        }
        
        private Client _currentUser;

        public Client CurrentUser
        {
            get => _currentUser;
            set => Set(ref _currentUser, value);
        }
        #region Commands

        #region ShowServicesCommand

        private ICommand _showServicesCommand;
        public ICommand ShowServicesCommand => _showServicesCommand
            ??= new RelayCommand(OnShowServicesCommandExecuted, CanShowServicesCommandExecute);
        
        private void OnShowServicesCommandExecuted(object parameter)
            => CurrentViewModel = new ServicesViewModel(new ViewModelLocator(), _servicesRepository);
        
        private bool CanShowServicesCommandExecute(object parameter) => true;

        #endregion
        
        #region ShowStatisticsCommand
        
        private ICommand _showStatisticsCommand;
        public ICommand ShowStatisticsCommand => _showStatisticsCommand
            ??= new RelayCommand(OnShowStatisticsCommandExecuted, CanShowStatisticsCommandExecute);
        
        private void OnShowStatisticsCommandExecuted(object parameter)
            => CurrentViewModel = new StatisticsViewModel(_statisticsService, _reservationsRepository);
        
        private bool CanShowStatisticsCommandExecute(object parameter) => true;
        
        #endregion

        #region ShowRoomTypesCommand

        private ICommand _showRoomTypesCommand;
        
        public ICommand ShowRoomTypesCommand => _showRoomTypesCommand
            ??= new RelayCommand(OnShowRoomTypesCommandExecuted, CanShowRoomTypesCommandExecute);
        
        private bool CanShowRoomTypesCommandExecute(object parameter) => true;

        private void OnShowRoomTypesCommandExecuted(object parameter)
            => CurrentViewModel = new RoomTypesViewModel(_roomTypesRepository);

        #endregion

        private ICommand _showRoomsCommand;
        
        public ICommand ShowRoomsCommand => _showRoomsCommand
            ??= new RelayCommand(OnShowRoomsCommandExecuted, CanShowRoomsCommandExecute);
        
        private bool CanShowRoomsCommandExecute(object parameter) => true;

        private void OnShowRoomsCommandExecuted(object parameter)
            => CurrentViewModel = new RoomsViewModel(_roomsRepository, new ViewModelLocator());

        private ICommand _showClientReservationCommand;
        
        public ICommand ShowClientReservationCommand => _showClientReservationCommand
            ??= new RelayCommand(OnShowClientReservationCommandExecute, CanShowClientReservationCommandExecute);
        
        private bool CanShowClientReservationCommandExecute(object parameter) => true;

        private void OnShowClientReservationCommandExecute(object parameter)
            => CurrentViewModel = new ReservationViewModel(new ViewModelLocator(), _reservationsRepository);


        #region ShowClientsView

        private ICommand _showClientsViewCommand;

        public ICommand ShowClientsViewCommand => _showClientsViewCommand
            ??= new RelayCommand(OnShowClientsViewCommandExecute, CanShowClientsViewCommandExecute);
        
        private bool CanShowClientsViewCommandExecute(object parameter) => true;

        private void OnShowClientsViewCommandExecute(object parameter)
            => CurrentViewModel = new ClientsViewModel(_clientsRepository);

        #endregion
        #region ShowReservationsView

        private ICommand _showReservationsViewCommand;

        public ICommand ShowReservationsViewCommand => _showReservationsViewCommand
            ??= new RelayCommand(OnShowReservationsViewCommandExecute, CanShowReservationsViewCommandExecute);
        
        private bool CanShowReservationsViewCommandExecute(object parameter) => true;

        private void OnShowReservationsViewCommandExecute(object parameter)
            => CurrentViewModel = new ReservationsViewModel(_reservationsRepository);

        #endregion
        
        #endregion
        #region Properties
        
        private readonly IRepository<Client> _clientsRepository;
        private readonly IRepository<Reservation> _reservationsRepository;

        #region CurrentViewModel

        private ViewModel _currentViewModel;
        private readonly IRepository<Room> _roomsRepository;
        private readonly IRepository<Service> _servicesRepository;
        private readonly IStatisticsService _statisticsService;
        private readonly IRepository<RoomType> _roomTypesRepository;

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set => Set(ref _currentViewModel, value);
        }

        #endregion
        
        #endregion
        public MainViewModel(IRepository<Client> clientsRepository,
            IRepository<Reservation> reservationsRepository,
            IRepository<RoomType> roomTypesRepository,
            IRepository<Room> roomsRepository, IRepository<Service> servicesRepository,
            IStatisticsService statisticsService)
        {
            _roomTypesRepository = roomTypesRepository;
            _clientsRepository = clientsRepository;
            _reservationsRepository = reservationsRepository;
            _roomsRepository = roomsRepository;
            _servicesRepository = servicesRepository;

            _statisticsService = statisticsService;
            
            Date = DateTime.Now;
        }
    }
}