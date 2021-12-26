using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class NewRoomWindowViewModel : ViewModel
    {
        #region Fields
        
        private readonly IRepository<Room> _roomsRepository;
        private readonly IRepository<RoomType> _roomTypesRepository;
        
        #endregion

        #region Properties

        #region RoomTypesList

        private ObservableCollection<RoomType> _roomTypes;

        public ObservableCollection<RoomType> RoomTypes
        {
            get => _roomTypes;
            set => Set(ref _roomTypes, value);
        }

        #endregion

        #region SelectedRoomType

        private RoomType _selectedRoomType;

        public RoomType SelectedRoomType
        {
            get => _selectedRoomType;
            set => Set(ref _selectedRoomType, value);
        }

        #endregion

        #region Number

        private int _number;

        public int Number
        {
            get => _number;
            set => Set(ref _number, value);
        }

        #endregion

        #endregion

        #region Commands

        #region AddNewRoomCommand

        private ICommand _addNewRoomCommand;
        public ICommand AddNewRoomCommand => _addNewRoomCommand
            ??= new RelayCommand(OnShowAddNewRoomCommandExecuted, CanAddNewRoomCommandExecute);

        private void OnShowAddNewRoomCommandExecuted(object parameter)
            => _roomsRepository.Add(new Room {Number = Number, RoomType = SelectedRoomType});

        private bool CanAddNewRoomCommandExecute(object parameter) => true;

        #endregion

        #endregion
        
        public NewRoomWindowViewModel(IRepository<Room> roomsRepository,
            IRepository<RoomType> roomTypesRepository)
        {
            _roomsRepository = roomsRepository;
            _roomTypesRepository = roomTypesRepository;

            RoomTypes = new ObservableCollection<RoomType>(_roomTypesRepository.All);
            SelectedRoomType = RoomTypes.FirstOrDefault();
        }
    }
}