using System;
using System.Collections.ObjectModel;
using HS.Context.Entities;

namespace HS.Services
{
    public interface IStatisticsService
    {
        public ObservableCollection<Reservation> GetReservationsByTime(DateTime lowerBound, DateTime upperBound);
        public int GetIncome(DateTime lowerBound, DateTime upperBound);
    }
}