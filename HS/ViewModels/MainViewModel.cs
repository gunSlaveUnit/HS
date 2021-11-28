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
        private Client _currentUser;

        public Client CurrentUser
        {
            get => _currentUser;
            set => Set(ref _currentUser, value);
        }
        #region Commands

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

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set => Set(ref _currentViewModel, value);
        }

        #endregion
        
        #endregion
        public MainViewModel(IRepository<Client> clientsRepository,
            IRepository<Reservation> reservationsRepository)
        {
            _clientsRepository = clientsRepository;
            _reservationsRepository = reservationsRepository;
            
            var items = clientsRepository.All.ToArray();
        }
    }
}