using Domain.Common;

namespace Domain.Entity
{
    public class Vocabulary : AuditEntity
    {
        public string Word { get; set; }
        public string Definition { get; set; }
        public string Example { get; set; }
        public string Phonetic { get; set; }
        public string AudioUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Topic { get; set; } // Food, Travel, Business
        public string Level { get; set; } // A1-B2

        public ICollection<VocabularySet> VocabularySets { get; set; } = new List<VocabularySet>();
        public ICollection<VocabularySetItem> VocabularySetItems { get; set; } = new List<VocabularySetItem>();

    }
}