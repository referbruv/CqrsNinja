namespace CqrsNinja.Contracts.Data.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime AddedOn { get; set; }
    }
}
