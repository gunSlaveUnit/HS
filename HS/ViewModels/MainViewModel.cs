using System;
using System.Linq;
using Hotel.Context.Entities;
using Hotel.Interfaces;
using HS.Services;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel(IRepository<Client> clientsRepository, IBookingService bookingService)
        {
            var items = clientsRepository.All.ToArray();
            var r = bookingService.Reservate(items.FirstOrDefault(), DateTime.Now, DateTime.Now);
        }
    }
}