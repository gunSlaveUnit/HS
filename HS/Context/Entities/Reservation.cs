using System;
using System.ComponentModel.DataAnnotations;
using HS.Context.Entities.Base;

namespace HS.Context.Entities
{
    public class Reservation : Entity
    {
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int RoomId { get; set; }
        public virtual Room RoomType { get; set; }
    }
}