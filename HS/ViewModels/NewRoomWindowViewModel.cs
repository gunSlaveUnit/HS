using Hotel.Interfaces;
using HS.Context.Entities;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class NewRoomWindowViewModel : ViewModel
    {
        private readonly IRepository<Room> _roomsRepository;
        private readonly IRepository<RoomType> _roomTypesRepository;

        public NewRoomWindowViewModel(IRepository<Room> roomsRepository,
            IRepository<RoomType> roomTypesRepository)
        {
            _roomsRepository = roomsRepository;
            _roomTypesRepository = roomTypesRepository;
        }
    }
}