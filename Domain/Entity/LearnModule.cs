using Domain.Common;
using Domain.Enum;

namespace Domain.Entity
{
    public class LearnModule : AuditEntity
    {
        public string Title { get; set; } // "Ngữ pháp căn bản", "Từ vựng chủ đề gia đình"
        public ModuleType Type { get; set; } // Grammar, Vocabulary, Listening, Speaking, Reading, Writing
        public int Order { get; set; }
        public int EstimatedHours { get; set; }

        public Guid LearningPathId { get; set; }
        public LearningPath LearningPath { get; set; }

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}