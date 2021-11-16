using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hotel.Context.Entities.Base;

namespace Hotel.Context.Entities
{
    public class Reservation : Entity
    {
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public DateTime DepartureDate { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}