using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class LearningUnit : AuditEntity
    {
        public string Name { get; set; } = null!;
        public int Order { get; set; }
        public Guid LearningPathId { get; set; }

        public LearningPath LearningPath { get; set; } = null!;
        public ICollection<VocabularyItem> VocabularyItems { get; set; } = new List<VocabularyItem>();
    }
}
