using System.ComponentModel.DataAnnotations;
using HS.Context.Entities.Base;

namespace HS.Context.Entities
{
    public class Room : Entity
    {
        [Required]
        public int Number { get; set; }
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}