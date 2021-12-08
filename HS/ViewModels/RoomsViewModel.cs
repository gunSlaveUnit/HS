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
        public Room SelectedRoom
        {
            get => _selectedRoom;
            set => Set(ref _selectedRoom, value);
        }

        public RoomsViewModel(IRepository<Room> roomsRepository)
        {
            _roomsRepository = roomsRepository;
            var rooms = _roomsRepository.All;
            Rooms = new ObservableCollection<Room>(rooms);
        }
    }
}