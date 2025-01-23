using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Domain.Entities
{
    public class BaseEntity: AuditableEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
