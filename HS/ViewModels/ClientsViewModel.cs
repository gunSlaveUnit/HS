using Hotel.Context.Entities;
using Hotel.Interfaces;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class ClientsViewModel : ViewModel
    {
        public ClientsViewModel(IRepository<Client> clientsRepository)
        {
            
        }
    }
}