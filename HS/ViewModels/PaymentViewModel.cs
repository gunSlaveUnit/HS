using System;
using System.Linq;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class PaymentViewModel : ViewModel
    {
        private readonly ViewModelLocator _locator;
        private readonly IRepository<Reservation> _reservationsRepository;
        private readonly IRepository<OrderedService> _orderedServicesRepository;

        private string _livingPrice;
        public string LivingPrice
        {
            get => _livingPrice;
            set => Set(ref _livingPrice, value);
        }
        
        private string _orderedServicesPrice;

        public string OrderedServicesPrice
        {
            get => _orderedServicesPrice;
            set => Set(ref _orderedServicesPrice, value);
        }

        private string _sum;

        public string Sum
        {
            get => _sum;
            set => Set(ref _sum, value);
        }

        public PaymentViewModel(ViewModelLocator locator,
            IRepository<Reservation> reservationsRepository,
            IRepository<OrderedService> orderedServicesRepository)
        {
            _locator = locator;

            _reservationsRepository = reservationsRepository;
            _orderedServicesRepository = orderedServicesRepository;

            LivingPrice = _locator.MainViewModel.SelectedReservation.Cost.ToString();
            OrderedServicesPrice = _orderedServicesRepository.All.Where(
                s => s.ReservationId == _locator.MainViewModel.SelectedReservation.Id
            ).Sum(s => s.CheckoutPrice).ToString();
            Sum = (Convert.ToInt32(LivingPrice) + Convert.ToInt32(OrderedServicesPrice)).ToString();
        }
    }
}