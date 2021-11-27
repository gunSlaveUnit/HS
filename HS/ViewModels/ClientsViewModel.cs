using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Hotel.Context.Entities;
using Hotel.Interfaces;
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

        public ClientsViewModel(IRepository<Client> clientsRepository)
        {
            _clientsRepository = clientsRepository;
            Clients = _clientsRepository.All.ToList();
        }
    }
}