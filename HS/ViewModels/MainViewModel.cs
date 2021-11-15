using System.Linq;
using Hotel.Context.Entities;
using Hotel.Interfaces;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel(IRepository<Client> clientsRepository)
        {
            var items = clientsRepository.All.ToArray();
        }
    }
}