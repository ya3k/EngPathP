using Domain.Common;
using Domain.Enum;
using System.Reflection;

namespace Domain.Entity
{
    public class Lesson : AuditEntity
    {
        public string Title { get; set; }
        public string Content { get; set; } // HTML/Text content
        public int EstimatedMinutes { get; set; } // Thời gian ước tính
        public LessonType Type { get; set; }
        public int Order { get; set; }
        public Guid? LearnModuleId { get; set; }
        public LearnModule? LearnModule { get; set; }
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}