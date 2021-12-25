using System;
using HS.Services;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class StatisticsViewModel : ViewModel
    {
        private readonly IStatisticsService _statisticsService;
        private int _count;
        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }
        private DateTime _lowerBound;

        public DateTime LowerBound
        {
            get => _lowerBound;
            set => Set(ref _lowerBound, value);
        }
        private DateTime _upperBound;

        public DateTime UpperBound
        {
            get => _upperBound;
            set => Set(ref _upperBound, value);
        }
        public StatisticsViewModel(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
            Count = _statisticsService.GetIncome(LowerBound, UpperBound);
        }
    }
}