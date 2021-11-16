using System;
using System.Linq;
using System.Windows.Input;
using Hotel.Context.Entities;
using Hotel.Infrastructure.Commands.Base;
using Hotel.Interfaces;
using HS.Services;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class MainViewModel : ViewModel
    {
        #region Commands

        #region ShowClientsView

        private ICommand _showClientsViewCommand;

        public ICommand ShowClientsViewCommand => _showClientsViewCommand
            ??= new RelayCommand(OnShowClientsViewCommandExecute, CanShowClientsViewCommandExecute);
        
        private bool CanShowClientsViewCommandExecute(object parameter) => true;

        private void OnShowClientsViewCommandExecute(object parameter)
        {
            
        }

        #endregion
        #region ShowReservationsView

        private ICommand _showReservationsViewCommand;

        public ICommand ShowReservationsViewCommand => _showReservationsViewCommand
            ??= new RelayCommand(OnShowClientsViewCommandExecute, CanShowClientsViewCommandExecute);
        
        private bool CanShowReservationsViewCommandExecute(object parameter) => true;

        private void OnShowReservationsViewCommandExecute(object parameter)
        {
            
        }

        #endregion
        
        #endregion
        #region Properties

        #region CurrentViewModel

        private ViewModel _currentViewModel;

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set => Set(ref _currentViewModel, value);
        }

        #endregion
        
        #endregion
        public MainViewModel(IRepository<Client> clientsRepository, IBookingService bookingService)
        {
            var items = clientsRepository.All.ToArray();
            var r = bookingService.Reservate(items.FirstOrDefault(), DateTime.Now, DateTime.Now);
        }
    }
}