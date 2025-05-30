using Domain.Common;
using Domain.Entity;

namespace Domain.Identity
{
    public class UserVocabulary : AuditEntity
    {
        public DateTime LastReviewed { get; set; }
        public int MasteryLevel { get; set; } // 0-5
        public bool IsLearned { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public Guid VocabularyId { get; set; }
        public Vocabulary Vocabulary { get; set; }
    }
}