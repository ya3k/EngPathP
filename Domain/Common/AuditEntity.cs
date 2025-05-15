
namespace Domain.Common;

public class AuditEntity : SoftDeleteEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; } = DateTime.Now;

    public string? LastModifiedBy { get; set; }

}