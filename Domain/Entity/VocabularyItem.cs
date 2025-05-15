using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class VocabularyItem : AuditEntity
    {
        public string Word { get; set; } = null!;
        public string Definition { get; set; } = null!;
        public string? ExampleSentence { get; set; }
        public string? AudioUrl { get; set; }
        public Guid LearningUnitId { get; set; }

        public LearningUnit LearningUnit { get; set; } = null!;
    }
}
