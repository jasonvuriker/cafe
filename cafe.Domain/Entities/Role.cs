namespace cafe.Domain.Entities;

public class Role
{
    public Role()
    {
        RolePermissions = new HashSet<RolePermission>();
        Users = new HashSet<User>();
    }

    public int RoleId { get; set; }

    public string Name { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; }

    public virtual ICollection<User> Users { get; set; }
}
