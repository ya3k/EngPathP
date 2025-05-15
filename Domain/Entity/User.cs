using Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class User : IdentityUser
    {
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string? FullName { get; set; }
        public int IsPremium { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public ICollection<LearningPath> LearningPaths { get; set; } = new List<LearningPath>();
        public ICollection<UserProgress> Progresses { get; set; } = new List<UserProgress>();
        public ICollection<SpacedRepetitionLog> SRLogs { get; set; } = new List<SpacedRepetitionLog>();
    }
}
