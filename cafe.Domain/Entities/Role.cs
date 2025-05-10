namespace cafe.Domain.Entities;

public class Role
{
    public Role()
    {
        Permissions = new HashSet<Permission>();
        Users = new HashSet<User>();
    }

    public int RoleId { get; set; }

    public string Name { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; }

    public virtual ICollection<User> Users { get; set; }
}
