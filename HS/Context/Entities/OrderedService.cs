using HS.Context.Entities.Base;

namespace HS.Context.Entities
{
    public class OrderedService : Entity
    {
        public int ClientId { get; set; }
        public int ReservationId { get; set; }
        public int CheckoutPrice { get; set; }
    }
}