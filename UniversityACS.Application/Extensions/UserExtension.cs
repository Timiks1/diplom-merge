using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Extensions;

public static class UserExtension
{
    public static async Task<ApplicationUser>? GetUserFromContextAsync(this HttpContext httpContext,
        ApplicationDbContext context, CancellationToken cancellationToken = default)
    {
        var userNameClaim = httpContext.User.Claims.FirstOrDefault(x => x.Type == "UserName");
        var userName = userNameClaim?.Value;
        if (userName is null) throw new UnauthorizedAccessException();

        var user = await context.ApplicationUsers.FirstOrDefaultAsync(x => x.UserName == userName, cancellationToken);
        if (user == null) throw new UnauthorizedAccessException();

        return user;
    }
}