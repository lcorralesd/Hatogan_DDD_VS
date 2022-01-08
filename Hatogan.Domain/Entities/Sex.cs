using Hatogan.Domain.Interfaces;

namespace Hatogan.Domain.Entities
{
    public class Sex : BaseEntity<short>, IAggregateRoot
    {
        public string Name { get; private set; } = default!;

        public Sex(string name)
        {
            Name = name;
        }
    }
}
