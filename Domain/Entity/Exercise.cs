using Domain.Common;
using Domain.Enum;

namespace Domain.Entity
{
    public class Exercise : AuditEntity
    {
        public string Question { get; set; }
        public ExerciseType Type { get; set; }
        public string Options { get; set; } // JSON array for multiple choice
        public string CorrectAnswer { get; set; }
        public string Explanation { get; set; }
        public int Difficulty { get; set; } // 1-5                                          // Thêm thông tin chấm điểm
        public int MaxPoints { get; set; } = 10;
        // Tách riêng bài tập speaking/writing
        public string? AudioPromptUrl { get; set; } // Cho bài nói
        public string? ImagePromptUrl { get; set; } // Cho bài viết
        public Guid? LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public Guid? VocabularyId { get; set; }
        public Vocabulary Vocabulary { get; set; }

        public Guid? GrammarTopicId { get; set; }
        public GrammarTopic GrammarTopic { get; set; }
    }
}