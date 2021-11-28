using System.Collections.Generic;
using System.Linq;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class RoomsViewModel : ViewModel
    {
        private IRepository<Room> _roomsRepository;
        private List<Room> _rooms;

        public List<Room> Rooms
        {
            get => _rooms;
            set => Set(ref _rooms, value);
        }

        public RoomsViewModel(IRepository<Room> roomsRepository)
        {
            _roomsRepository = roomsRepository;
            Rooms = _roomsRepository.All.ToList();
        }
    }
}