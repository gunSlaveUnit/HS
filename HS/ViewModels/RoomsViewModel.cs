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

        #region CreateNewRoomCommand

        private ICommand _createNewRoomCommand;
        public ICommand CreateNewRoomCommand => _createNewRoomCommand
            ??= new RelayCommand(OnCreateNewRoomCommandExecuted, CanCreateNewRoomCommandExecute);
        
        private bool CanCreateNewRoomCommandExecute(object p) => true;

        private void OnCreateNewRoomCommandExecuted(object p)
        {
            //TODO: It works, but it is not good in MVVM architecture
            var newRoomType = new NewRoomWindowView();
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
            _locator.NewReservByClientViewModel.DepartureDate = ArrivalDate;
            _locator.NewReservByClientViewModel.SelectedRoom = SelectedRoom;
            _locator.NewReservByClientViewModel.CurrentClient = _locator.MainViewModel.CurrentUser;
            if (IsHours)
            {
                _locator.NewReservByClientViewModel.DepartureDate = ArrivalDate.AddHours(Convert.ToDouble(PeriodsAmount));
                _locator.NewReservByClientViewModel.Cost = SelectedRoom.RoomType.CostPerHour * Convert.ToInt32(PeriodsAmount);
            }
            if (IsDays)
            {
                _locator.NewReservByClientViewModel.DepartureDate = ArrivalDate.AddDays(Convert.ToDouble(PeriodsAmount));
                _locator.NewReservByClientViewModel.Cost = SelectedRoom.RoomType.CostPerDay * Convert.ToInt32(PeriodsAmount);
            }
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
        
        private string _minCapacityFilter;

        public string MinCapacityFilter
        {
            get => _minCapacityFilter;
            set => Set(ref _minCapacityFilter, value);
        }
        
        private string _maxCapacityFilter;

        public string MaxCapacityFilter
        {
            get => _maxCapacityFilter;
            set => Set(ref _maxCapacityFilter, value);
        }
        
        private string _minPrice;

        public string MinPrice
        {
            get => _minPrice;
            set => Set(ref _minPrice, value);
        }
        
        private string _maxPrice;

        public string MaxPrice
        {
            get => _maxPrice;
            set => Set(ref _maxPrice, value);
        }

        #region Commands

        #region ApplyFiltersCommand
        
        private ICommand _applyFiltersCommand;
        
        public ICommand ApplyFiltersCommand => _applyFiltersCommand
            ??= new RelayCommand(OnApplyFiltersCommandExecuted, CanApplyFiltersCommandExecute);
        
        private bool CanApplyFiltersCommandExecute(object parameter) => true;

        private void OnApplyFiltersCommandExecuted(object parameter)
        {
            var rooms = _roomsRepository.All
                .Where(r => r.RoomType.Capacity >= Convert.ToInt32(MinCapacityFilter) 
                            && r.RoomType.Capacity <= Convert.ToInt32(MaxCapacityFilter));
            if (IsHours)
                rooms = rooms.Where(r => r.RoomType.CostPerHour >= Convert.ToInt32(MinPrice) 
                                         && r.RoomType.CostPerHour <= Convert.ToInt32(MaxPrice));
            else
                rooms = rooms.Where(r => r.RoomType.CostPerDay >= Convert.ToInt32(MinPrice) 
                                         && r.RoomType.CostPerDay <= Convert.ToInt32(MaxPrice));
            Rooms = new ObservableCollection<Room>(rooms);
        }
        
        #endregion

        #endregion

        public RoomsViewModel(IRepository<Room> roomsRepository, ViewModelLocator locator)
        {
            _locator = locator;
            _roomsRepository = roomsRepository;
            var rooms = _roomsRepository.All;
            Rooms = new ObservableCollection<Room>(rooms);

            MinCapacityFilter = rooms.Min(r => r.RoomType.Capacity).ToString();
            MaxCapacityFilter = rooms.Max(r => r.RoomType.Capacity).ToString();
            
            MinPrice = rooms.Min(r => r.RoomType.CostPerHour).ToString();
            MaxPrice = rooms.Max(r => r.RoomType.CostPerDay).ToString();
            
            ArrivalDate = DateTime.Today;
            IsDays = true;
        }
    }
}