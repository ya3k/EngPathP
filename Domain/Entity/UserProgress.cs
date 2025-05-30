using Domain.Common;
using Domain.Entity;

namespace Domain.Identity
{
    public class UserProgress : AuditEntity
    {
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int MinutesStudied { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid? LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public Guid? ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}