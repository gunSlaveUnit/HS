using System;
using System.Linq;
using System.Windows.Input;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class StatisticsViewModel : ViewModel
    {
        private readonly IStatisticsService _statisticsService;
        private int _reservationsAmountInCurrentMonth;

        public int ReservationsAmountInCurrentMonth
        {
            get => _reservationsAmountInCurrentMonth;
            set => Set(ref _reservationsAmountInCurrentMonth, value);
        }
        
        private int _reservationsAmountInPreviousMonth;

        public int ReservationsAmountInPreviousMonth
        {
            get => _reservationsAmountInPreviousMonth;
            set => Set(ref _reservationsAmountInPreviousMonth, value);
        }
        
        private int _incomeCurrentMonth;
        public int IncomeCurrentMonth
        {
            get => _incomeCurrentMonth;
            set => Set(ref _incomeCurrentMonth, value);
        }
        
        private int _incomePreviousMonth;
        public int IncomePreviousMonth
        {
            get => _incomePreviousMonth;
            set => Set(ref _incomeCurrentMonth, value);
        }
        
        private DateTime _lowerBound;

        public DateTime LowerBound
        {
            get => _lowerBound;
            set => Set(ref _lowerBound, value);
        }
        private DateTime _upperBound;
        private readonly IRepository<Reservation> _reservationsRepository;

        public DateTime UpperBound
        {
            get => _upperBound;
            set => Set(ref _upperBound, value);
        }

        private void Update()
        {
            DateTime lowerBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime upperBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
                DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            IncomeCurrentMonth = _statisticsService.GetIncome(lowerBound, upperBound);
            IncomePreviousMonth = _statisticsService.GetIncome(
                new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1,
                    DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1)));
            ReservationsAmountInCurrentMonth = _statisticsService.GetReservationsByTime(
                lowerBound, upperBound).Count;
            ReservationsAmountInPreviousMonth = _statisticsService.GetReservationsByTime(
                new DateTime(DateTime.Now.Year, DateTime.Now.Month-1, 1),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month-1,
                    DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month-1))).Count;
        }
        
        private ICommand _updateStatistics;
        public ICommand UpdateStatisticsCommand => _updateStatistics
            ??= new RelayCommand(OnUpdateStatisticsCommandExecuted, CanUpdateStatisticsCommandExecute);

        private bool CanUpdateStatisticsCommandExecute(object p) => true;

        private void OnUpdateStatisticsCommandExecuted(object p) => Update();
        public StatisticsViewModel(IStatisticsService statisticsService,
            IRepository<Reservation> reservationsRepository)
        {
            _statisticsService = statisticsService;
            _reservationsRepository = reservationsRepository;

            LowerBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            UpperBound = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
                DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }
    }
}