using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HS.Context.Entities.Base;

namespace HS.Context.Entities
{
    public class ClientStatus : Entity
    {
        [Required]
        public string Title { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}