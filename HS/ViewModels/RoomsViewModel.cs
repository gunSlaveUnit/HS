using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.ViewModels.Base;
using HS.Views.Windows.Creation;

namespace HS.ViewModels
{
    public class RoomsViewModel : ViewModel
    {
        #region Commands
        
        #region CreateNewRoomTypeCommand
        
        private ICommand _createNewRoomTypeCommand;
        public ICommand CreateNewRoomTypeCommand => _createNewRoomTypeCommand
            ??= new RelayCommand(OnCreateNewRoomTypeCommandExecuted, CanCreateNewRoomTypeCommandExecute);
        
        private bool CanCreateNewRoomTypeCommandExecute(object p) => true;

        private void OnCreateNewRoomTypeCommandExecuted(object p)
        {
            //TODO: It works, but it is not good in MVVM architecture
            var newRoomType = new NewRoomType();
            newRoomType.Owner = Application.Current.MainWindow;
            newRoomType.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newRoomType.ShowDialog();
        }
        
        #endregion
        
        private ICommand _makeReservationCommand;
        public ICommand MakeReservationCommand => _makeReservationCommand
            ??= new RelayCommand(OnMakeReservationCommandExecuted, CanMakeReservationCommandExecute);
        
        private bool CanMakeReservationCommandExecute(object p) => p is Room;

        private void OnMakeReservationCommandExecuted(object p)
        {
            if (p is not Room) return;
            //TODO: It works, but it is not good in MVVM architecture
            var newReservationByClientWindow = new NewReservationByClient();
            _locator.NewReservByClientViewModel.ArrivalDate = ArrivalDate;
            _locator.NewReservByClientViewModel.IsDays = IsDays;
            _locator.NewReservByClientViewModel.IsHours = IsHours;
            _locator.NewReservByClientViewModel.SelectedRoom = SelectedRoom;
            _locator.NewReservByClientViewModel.PeriodsAmount = PeriodsAmount;
            newReservationByClientWindow.Owner = Application.Current.MainWindow;
            newReservationByClientWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newReservationByClientWindow.ShowDialog();
        }

        #endregion
        private IRepository<Room> _roomsRepository;
        private ObservableCollection<Room> _rooms;

        public ObservableCollection<Room> Rooms
        {
            get => _rooms;
            set => Set(ref _rooms, value);
        }

        private Room _selectedRoom;
        private readonly ViewModelLocator _locator;

        public Room SelectedRoom
        {
            get => _selectedRoom;
            set => Set(ref _selectedRoom, value);
        }

        private DateTime _arrivalDate;

        public DateTime ArrivalDate
        {
            get => _arrivalDate;
            set => Set(ref _arrivalDate, value);
        }
        private string _periodsAmount;

        public string PeriodsAmount
        {
            get => _periodsAmount;
            set => Set(ref _periodsAmount, value);
        }

        private bool _isHours;

        public bool IsHours
        {
            get => _isHours;
            set => Set(ref _isHours, value);
        }
        
        private bool _isDays;

        public bool IsDays
        {
            get => _isDays;
            set => Set(ref _isDays, value);
        }

        public RoomsViewModel(IRepository<Room> roomsRepository, ViewModelLocator locator)
        {
            _locator = locator;
            _roomsRepository = roomsRepository;
            var rooms = _roomsRepository.All;
            Rooms = new ObservableCollection<Room>(rooms);
            ArrivalDate = DateTime.Now;
            IsDays = true;
        }
    }
}