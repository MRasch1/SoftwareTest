namespace SoftwareTest.Services
{
    using Microsoft.AspNetCore.Identity;
    using SoftwareTest.Data;

    public class UserRoleService : IUserRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AssignRoleToUserAsync(string userEmail, string roleName)
        {
            // Ensure the role exists
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }

            // Find the user by email
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                throw new Exception($"User with email '{userEmail}' not found.");
            }

            // Assign the role to the user
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to assign role: {errors}");
            }
        }
    }

}
