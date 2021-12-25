using HS.Context.Entities.Base;

namespace HS.Context.Entities
{
    public class OrderedService : Entity
    {
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public int ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
        public int CheckoutPrice { get; set; }
    }
}