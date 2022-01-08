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
    public class SexConfig : IEntityTypeConfiguration<Sex>
    {
        public void Configure(EntityTypeBuilder<Sex> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(10);
            builder.HasData(new Sex("Hembra")
            {
                Id = 1,
            },
            new Sex("Macho")
            {
                Id = 2,
            });
        }
    }
}
