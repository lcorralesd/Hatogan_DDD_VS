using Hatogan.Domain.Interfaces;
using Hatogan.Domain.ValueObjects;

namespace Hatogan.Domain.Entities
{
    public class Category : BaseEntity<int>, IAggregateRoot
    {
        public string Name { get; private set; } = default!;
        //public CategoryRange SinceUntil { get; private set; } = default!;

        public Category(string name)
        {
            Name = name;
            //SinceUntil = sinceUntil;
        }
    }
}
