using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Achievement : AuditEntity
    {
        public string Name { get; set; } // "Học 7 ngày liên tiếp", "Hoàn thành A1"
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
