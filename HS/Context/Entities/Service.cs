using System.ComponentModel.DataAnnotations;
using HS.Context.Entities.Base;

namespace HS.Context.Entities
{
    public class Service : Entity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
    }
}