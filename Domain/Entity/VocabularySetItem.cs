using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class VocabularySetItem
    {
        public Guid VocabularySetId { get; set; }
        public VocabularySet VocabularySet { get; set; }

        public Guid VocabularyId { get; set; }
        public Vocabulary Vocabulary { get; set; }

        public int Order { get; set; } // Thứ tự trong set

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true; // Trạng thái hoạt động của item
    }
}
