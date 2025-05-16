using Domain.Common;
using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class LearningPath : AuditEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public Guid UserId { get; set; }
        public bool IsShared { get; set; } = false;

        public ApplicationUser User { get; set; } = null!;
        public ICollection<LearningUnit> Units { get; set; } = new List<LearningUnit>();
    }
}
