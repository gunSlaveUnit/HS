using System.Collections.Generic;
using HS.Context.Entities.Base;

namespace HS.Context.Entities
{
    public class RoomType : Entity
    {
        public int Capacity { get; set; }
        public int CostPerHour { get; set; }
        public int CostPerDay { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}