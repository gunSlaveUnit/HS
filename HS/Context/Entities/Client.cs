using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HS.Context.Entities.Base;

namespace Hotel.Context.Entities
{
    public class Client : Entity
    {
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string Passport { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Salt { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}