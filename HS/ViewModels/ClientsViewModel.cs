using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Hotel.Interfaces;
using Hotel.Views.Windows;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class ClientsViewModel : ViewModel
    {
        private IRepository<Client> _clientsRepository;
        private List<Client> _clients;

        public List<Client> Clients
        {
            get => _clients;
            set => Set(ref _clients, value);
        }

        private Client _selectedClient;

        public Client SelectedClient
        {
            get => _selectedClient;
            set => Set(ref _selectedClient, value);
        }
        
        #region Commands

        #region CreateNewClientCommand
        
        private ICommand _createNewClientCommand;
        public ICommand CreateNewClientCommand => _createNewClientCommand
            ??= new RelayCommand(OnCreateNewClientCommandExecuted, CanCreateNewClientCommandExecute);
        
        private bool CanCreateNewClientCommandExecute(object p) => true;

        private void OnCreateNewClientCommandExecuted(object p)
        {
            var newUserWindow = new SignUpWindow();
            newUserWindow.Owner = Application.Current.MainWindow;
            newUserWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newUserWindow.ShowDialog();
        }
        
        #endregion
        
        #region DeleteClientCommand
        
        private ICommand _deleteClientCommand;
        public ICommand DeleteClientCommand => _deleteClientCommand
            ??= new RelayCommand(OnDeleteClientCommandExecuted, CanDeleteClientCommandExecute);
        
        private bool CanDeleteClientCommandExecute(object p) => p is RoomType;

        private void OnDeleteClientCommandExecuted(object p)
        {
            if (p is not RoomType) return;
            var r = (RoomType) p;
            //_roomTypesRepository.DeleteBy(r.Id);
        }
        
        #endregion
        
        #endregion

        public ClientsViewModel(IRepository<Client> clientsRepository)
        {
            _clientsRepository = clientsRepository;
            Clients = _clientsRepository.All.ToList();
        }
    }
}