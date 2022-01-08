using Hatogan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Application.Interfaces
{
    public interface IInventoryContext
    {
        DbSet<Animal> Animals { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Origin> Origins { get; set; }
        DbSet<Sex> Sexs { get; set; }
        DbSet<Status> Statuses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
