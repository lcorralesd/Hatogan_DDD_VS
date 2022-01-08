using Hatogan.Domain.Interfaces;

namespace Hatogan.Domain.Entities
{
    public class Origin : BaseEntity<short>, IAggregateRoot
    {
        public string Name { get; private set; } = default!;

        public Origin(string name)
        {
            Name = name;
        }
    }
}
