using System;
using System.Collections.ObjectModel;
using System.Linq;
using Hotel.Interfaces;
using HS.Context.Entities;

namespace HS.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository<Reservation> _reservationsRepository;
        private readonly IRepository<OrderedService> _orderedServicesRepository;

        public StatisticsService(IRepository<Reservation> reservationsRepository,
            IRepository<OrderedService> orderedServicesRepository)
        {
            _reservationsRepository = reservationsRepository;
            _orderedServicesRepository = orderedServicesRepository;
        }

        public ObservableCollection<Reservation> GetReservationsByTime(DateTime lowerBound, DateTime upperBound)
            => new ObservableCollection<Reservation>(_reservationsRepository.All.Where(
                r => r.ArrivalDate >= lowerBound && r.DepartureDate <= upperBound));

        public int GetIncome(DateTime lowerBound, DateTime upperBound)
            => _reservationsRepository.All.Sum(r => r.Cost) 
               + _orderedServicesRepository.All.Sum(o => o.CheckoutPrice);
    }
}