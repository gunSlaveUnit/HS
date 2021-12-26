﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.ViewModels.Base;
using HS.Views.Windows;

namespace HS.ViewModels
{
    public class ReservationsViewModel : ViewModel
    {
        #region Fields

        private IRepository<Reservation> _reservationsRepository;
        private readonly IRepository<OrderedService> _orderedServicesRepository;

        #endregion

        #region Properties

        #region Reservations

        private List<Reservation> _reservations;

        public List<Reservation> Reservations
        {
            get => _reservations;
            set => Set(ref _reservations, value);
        }

        #endregion

        #region SelectedReservation

        private Reservation _selectedReservation;

        public Reservation SelectedReservation
        {
            get => _selectedReservation;
            set => Set(ref _selectedReservation, value);
        }

        #endregion

        #endregion
        
        #region Commands

        #region CalculateClientReservation

        private ICommand _calculateClientReservation;

        public ICommand CalculateClientReservation => _calculateClientReservation
            ??= new RelayCommand(OnCalculateClientReservationExecute, CanCalculateClientReservationExecute);
        
        private bool CanCalculateClientReservationExecute(object parameter) => true;

        private void OnCalculateClientReservationExecute(object parameter)
        {
            var newRoomType = new PaymentWindow();
            newRoomType.Owner = Application.Current.MainWindow;
            newRoomType.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newRoomType.ShowDialog();
        }

        #endregion

        #endregion

        public ReservationsViewModel(IRepository<Reservation> reservationsRepository,
            IRepository<OrderedService> orderedServicesRepository)
        {
            _reservationsRepository = reservationsRepository;
            _orderedServicesRepository = orderedServicesRepository;
            Reservations = _reservationsRepository.All.ToList();
        }
    }
}