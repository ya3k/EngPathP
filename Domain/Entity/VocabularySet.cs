using Domain.Common;

namespace Domain.Entity
{
    public class VocabularySet : AuditEntity
    {
        public string Name { get; set; } // "Từ vựng TOEIC Part 1", "300 từ vựng IELTS"
        public string Description { get; set; }

        public ICollection<VocabularySetItem> VocabularySetItems { get; set; } = new List<VocabularySetItem>();

    }
}