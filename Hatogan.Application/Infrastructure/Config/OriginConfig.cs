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
    public class OriginConfig : IEntityTypeConfiguration<Origin>
    {
        public void Configure(EntityTypeBuilder<Origin> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(20);
            builder.HasData(new Origin("Propio")
            {
                Id = 1,
            },
            new Origin("Comprado")
            {
                Id = 2,
            });
        }
    }
}
