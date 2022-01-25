using System.Collections.Generic;
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
    public class RoomTypesViewModel : ViewModel
    {
        private IRepository<RoomType> _roomTypesRepository;

        #region Properties

        #region RoomTypesList

        private List<RoomType> _roomTypes;

        public List<RoomType> RoomTypes
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

        #endregion
        
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
        
        #region DeleteNewRoomTypeCommand
        
        private ICommand _deleteRoomTypeCommand;
        public ICommand DeleteRoomTypeCommand => _deleteRoomTypeCommand
            ??= new RelayCommand(OnDeleteNewRoomTypeCommandExecuted, CanDeleteNewRoomTypeCommandExecute);
        
        private bool CanDeleteNewRoomTypeCommandExecute(object p) => p is RoomType;

        private void OnDeleteNewRoomTypeCommandExecuted(object p)
        {
            if (p is not RoomType) return;
            var r = (RoomType) p;
            _roomTypesRepository.DeleteBy(r.Id);
        }
        
        #endregion
        
        #endregion

        public RoomTypesViewModel(IRepository<RoomType> roomTypesRepository)
        {
            _roomTypesRepository = roomTypesRepository;
            RoomTypes = _roomTypesRepository.All.ToList();
        }
    }
}