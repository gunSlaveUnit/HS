using System.Collections.Generic;
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

        #region Document

        private string _document;

        public string Document
        {
            get => _document;
            set => Set(ref _document, value);
        }

        #endregion

        #endregion
        
        #region Commands

        #region CalculateClientReservation

        private ICommand _calculateClientReservation;

        public ICommand CalculateClientReservation => _calculateClientReservation
            ??= new RelayCommand(OnCalculateClientReservationExecute, CanCalculateClientReservationExecute);
        
        private bool CanCalculateClientReservationExecute(object p) => p is Reservation;

        private void OnCalculateClientReservationExecute(object parameter)
        {
            _locator.MainViewModel.SelectedReservation = SelectedReservation;
            var newRoomType = new PaymentWindow();
            newRoomType.Owner = Application.Current.MainWindow;
            newRoomType.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newRoomType.ShowDialog();
        }

        #endregion

        #region SearchReservationByClientDocument

        private ICommand _searchReservationByClientDocument;
        private readonly ViewModelLocator _locator;

        public ICommand SearchReservationByClientDocument => _searchReservationByClientDocument
            ??= new RelayCommand(OnSearchReservationByClientDocumentExecute, CanSearchReservationByClientDocumentExecute);
        
        private bool CanSearchReservationByClientDocumentExecute(object parameter) => true;

        private void OnSearchReservationByClientDocumentExecute(object parameter)
            => Reservations = _reservationsRepository.All.Where(r => r.Client.Document == Document).ToList();
        
        #endregion

        #endregion

        public ReservationsViewModel(IRepository<Reservation> reservationsRepository,
            IRepository<OrderedService> orderedServicesRepository,
            ViewModelLocator locator)
        {
            _locator = locator;
            _reservationsRepository = reservationsRepository;
            _orderedServicesRepository = orderedServicesRepository;
            Reservations = _reservationsRepository.All.ToList();
        }
    }
}