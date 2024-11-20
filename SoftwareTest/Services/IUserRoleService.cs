namespace SoftwareTest.Services
{

    public interface IUserRoleService
    {
        Task AssignRoleToUserAsync(string userEmail, string roleName);
    }

}
