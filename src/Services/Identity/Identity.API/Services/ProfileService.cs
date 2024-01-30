using IdentityModel;
using System.Security.Claims;

namespace Identity.API.Services;

public class ProfileService : IProfileService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ProfileService(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var userId = context.Subject.GetSubjectId();
        var user = await _userManager.FindByIdAsync(userId);

        var claims = new List<Claim>
        {
            new Claim(JwtClaimTypes.GivenName, user.UserName),
            new Claim(JwtClaimTypes.Email, user.Email),
        };

        var userRoles = await _userManager.GetRolesAsync(user);

        if (userRoles.Any())
            claims.Add(new Claim(JwtClaimTypes.Role, userRoles.First()));

        context.IssuedClaims = claims;
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        context.IsActive =
            (await _userManager.FindByIdAsync(context.Subject.GetSubjectId())) != null;
    }
}