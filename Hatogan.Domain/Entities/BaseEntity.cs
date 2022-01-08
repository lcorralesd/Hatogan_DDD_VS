namespace Hatogan.Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; } = default!;
        public bool Inactive { get; set; } = false;
    }
    
} 
