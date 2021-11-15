using Hotel.Interfaces;

namespace Hotel.Context.Entities.Base
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}