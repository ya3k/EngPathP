using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class LearningPath : AuditEntity
    {
        public string ThumbnailUrl { get; set; }
        public string Name { get; set; } // "Lộ trình A1", "Luyện thi TOEIC 500+"
        public string Level { get; set; } // A1, A2, B1, B2
        public int EstimatedWeeks { get; set; }
        public string Description { get; set; }
        public string Outcomes { get; set; } // "Học xong bạn có thể..."

        public ICollection<LearnModule> LearnModules { get; set; }

        public LearningPath()
        {
            LearnModules = new List<LearnModule>();
        }

    }
}
