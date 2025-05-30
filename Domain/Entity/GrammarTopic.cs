using Domain.Common;

namespace Domain.Entity
{
    public class GrammarTopic : AuditEntity
    {
        public string Title { get; set; } // "Thì hiện tại đơn", "Câu điều kiện"
        public string Explanation { get; set; }
        public string Examples { get; set; }
        public string Level { get; set; } // A1-B2

        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}