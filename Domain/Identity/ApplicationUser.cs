using Microsoft.AspNetCore.Identity;

namespace Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? PersonName { get; set; } = string.Empty;
        public string? RefreshToken { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime RefreshTokenExpirationDateTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
