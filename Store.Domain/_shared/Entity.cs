namespace Store.Domain._shared
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }


    }
}
