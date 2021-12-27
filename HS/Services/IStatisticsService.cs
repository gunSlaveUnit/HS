using System;
using System.Collections.ObjectModel;
using HS.Context.Entities;

namespace HS.Services
{
    public interface IStatisticsService
    {
        public ObservableCollection<Reservation> GetReservationsByTime(DateTime lowerBound, DateTime upperBound);
        public ObservableCollection<Reservation> GetReservationsByPeriod(DateTime lowerBound, DateTime upperBound);
        public int GetIncomeByTime(DateTime lowerBound, DateTime upperBound);
        public int GetIncomeByPeriod(DateTime lowerBound, DateTime upperBound);
    }
}