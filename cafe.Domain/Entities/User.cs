namespace cafe.Domain.Entities;

public class User
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public int? RoleId { get; set; }

    public bool IsActive { get; set; }

    public virtual Role? Role { get; set; }
}
