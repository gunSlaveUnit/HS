using System;
using System.Windows.Input;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class NewRoomTypeViewModel : ViewModel
    {
        #region Properties

        private string _capacity;

        public string Capacity
        {
            get => _capacity;
            set => Set(ref _capacity, value);
        }
        
        private string _costPerHour;

        public string CostPerHour
        {
            get => _costPerHour;
            set => Set(ref _costPerHour, value);
        }
        
        private string _costPerDay;

        public string CostPerDay
        {
            get => _costPerDay;
            set => Set(ref _costPerDay, value);
        }
        
        private string _title;

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        
        private string _description;

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }
        
        #endregion
        
        private readonly IRepository<RoomType> _roomTypesRepository;

        #region Commands

        #region AddNewRoomType

        private ICommand _createNewRoomTypeCommand;
        public ICommand CreateNewRoomTypeCommand => _createNewRoomTypeCommand
            ??= new RelayCommand(OnCreateNewRoomTypeCommandExecuted, CanCreateNewRoomTypeCommandExecute);
        
        private bool CanCreateNewRoomTypeCommandExecute(object p) => true;

        private void OnCreateNewRoomTypeCommandExecuted(object p)
        {
            var r = new RoomType()
            {
                Title = Title,
                Capacity = Convert.ToInt32(Capacity),
                CostPerHour = Convert.ToInt32(CostPerHour),
                CostPerDay = Convert.ToInt32(CostPerDay),
                Description = Description
            };
            _roomTypesRepository.Add(r);
        }

        #endregion

        #endregion
        
        public NewRoomTypeViewModel(IRepository<RoomType> roomTypesRepository)
        {
            _roomTypesRepository = roomTypesRepository;
        }
    }
}