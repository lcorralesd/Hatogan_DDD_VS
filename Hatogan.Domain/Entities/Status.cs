using Hatogan.Domain.Interfaces;

namespace Hatogan.Domain.Entities
{
    public class Status : BaseEntity<short>, IAggregateRoot
    {
        public string Name { get; private set; } = default!;

        public Status(string name)
        {
            Name = name;
        }
    }
}
