using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class SpacedRepetitionLog :AuditEntity
    {
        public Guid UserId { get; set; }
        public Guid VocabularyItemId { get; set; }

        public DateTime LastReviewedAt { get; set; }
        public DateTime NextReviewAt { get; set; }

        public int EaseFactor { get; set; }
        public int RepetitionCount { get; set; }

        public User User { get; set; } = null!;
        public VocabularyItem VocabularyItem { get; set; } = null!;
    }
}
