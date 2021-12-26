using System.Collections.Generic;
using System.Linq;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class RoomTypesViewModel : ViewModel
    {
        private IRepository<RoomType> _roomTypesRepository;
        
        private List<RoomType> _roomTypes;

        public List<RoomType> RoomTypes
        {
            get => _roomTypes;
            set => Set(ref _roomTypes, value);
        }

        public RoomTypesViewModel(IRepository<RoomType> roomTypesRepository)
        {
            _roomTypesRepository = roomTypesRepository;
            RoomTypes = _roomTypesRepository.All.ToList();
        }
    }
}