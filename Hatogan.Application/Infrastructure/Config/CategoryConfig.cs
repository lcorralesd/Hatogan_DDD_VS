using Hatogan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Application.Infrastructure.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(20);
            builder.HasData(new Category("Ternero")
            {
                Id = 1,
            },
            new Category("Novilla Destete")
            {
                Id = 2,
            },
            new Category("Maute Destete")
            {
                Id = 3,
            },
            new Category("Novilla de Levante")
            {
                Id = 4,
            },
            new Category("Maute de Levante")
            {
                Id = 5,
            },
            new Category("Novilla Vientre")
            {
                Id = 6,
            },
            new Category("Maute Ceba")
            {
                Id = 7,
            },
            new Category("Vaca")
            {
                Id = 8,
            },
            new Category("Toro")
            {
                Id = 9,
            });
        }
    }
}
