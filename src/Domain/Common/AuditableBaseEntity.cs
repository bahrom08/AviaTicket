using Domain.Entities.Users;

namespace Domain.Common;

public class AuditableBaseEntity : BaseEntity
{
    public Guid CreatedUserId { get; set; }
    public Guid? ModifiedUserId { get; set; }

    public User CreatedUser { get; set; }
    public User ModifiedUser { get; set; }
}
