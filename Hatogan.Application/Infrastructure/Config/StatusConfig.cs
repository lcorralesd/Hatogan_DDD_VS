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
    public class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(10);
            builder.HasData(new Status("Activo")
            {
                Id = 1,
            },
            new Sex("Enfermo")
            {
                Id = 2,
            },
            new Sex("Muerto")
            {
                Id = 2,
            },
            new Sex("Enfermo")
            {
                Id = 2,
            });
        }
    }
}
