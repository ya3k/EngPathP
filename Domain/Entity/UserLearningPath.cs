using Domain.Common;
using Domain.Entity;

namespace Domain.Identity
{
    public class UserLearningPath : AuditEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public double ProgressPercentage { get; set; }
        public int? TotalLessons { get; set; }
        public bool IsCompleted { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid LearningPathId { get; set; }
        public LearningPath LearningPath { get; set; }
    }
}