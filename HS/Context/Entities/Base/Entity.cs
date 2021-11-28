using Hotel.Interfaces;

namespace HS.Context.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}