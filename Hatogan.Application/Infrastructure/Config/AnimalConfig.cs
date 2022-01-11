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
    public class AnimalConfig : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(20);
            builder.Property(a => a.Number).IsRequired().HasMaxLength(15);
            builder.Property(a => a.Breed).HasMaxLength(20);
            builder.Property(a => a.Color).HasMaxLength(20);
            builder.Property(a => a.BirthDate).HasColumnType("date");
            builder.Property(a => a.AdmissionDate).HasColumnType("date");
            builder.Property(a => a.BirthWeight).HasPrecision(9, 2);
            builder.Property(a => a.IncomeWeight).HasPrecision(9, 2);
            builder.Property(a => a.ActualWeight).HasPrecision(9,2);
            builder.HasOne(a => a.Dam).WithMany(a => a.DamPups).HasForeignKey(a => a.DamId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Sire).WithMany(a => a.SirePups).HasForeignKey(a => a.SireId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(a => a.Number).IsUnique();
        }
    }
}
