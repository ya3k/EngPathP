using Domain.Common;
using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class UserAchievement : AuditEntity
    {
        public DateTime EarnedDate { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid AchievementId { get; set; }
        public Achievement Achievement { get; set; }
    }
}
