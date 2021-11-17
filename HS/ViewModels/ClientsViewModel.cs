using System.Linq;
using Hotel.Context.Entities;
using Hotel.Interfaces;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class ClientsViewModel : ViewModel
    {
        private IRepository<Client> _clientsRepository;
        private IQueryable<Client> _clients;

        public IQueryable<Client> Clients
        {
            get => _clients;
            set => Set(ref _clients, value);
        }

        public ClientsViewModel(IRepository<Client> clientsRepository)
        {
            _clientsRepository = clientsRepository;
            Clients = _clientsRepository.All;
        }
    }
}