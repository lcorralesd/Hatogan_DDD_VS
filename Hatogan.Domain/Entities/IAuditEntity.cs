using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Domain.Entities
{
    public interface IAuditEntity
    {
        string CreatedBy { get; set; } 
        DateTimeOffset CreatedDate { get; set; }
        string? UpdatedBy { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
        
    }
}
