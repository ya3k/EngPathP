using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UserProgress : AuditEntity
    {
        public Guid UserId { get; set; }
        public Guid LearningUnitId { get; set; }

        public int ProgressPercent { get; set; }
        public DateTime LastReviewedAt { get; set; }

        public User User { get; set; } = null!;
        public LearningUnit LearningUnit { get; set; } = null!;
    }
}
