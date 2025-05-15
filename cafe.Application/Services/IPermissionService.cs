namespace cafe.Application.Services;

public interface IPermissionService
{
    Task<List<string>> GetUserPermissions(int userId);
}
// CTRL + R, CTRL + G