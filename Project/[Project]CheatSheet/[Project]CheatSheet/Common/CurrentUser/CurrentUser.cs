using System.Security.Claims;
using _Project_CheatSheet.Common.CurrentUser.Interfaces;
using _Project_CheatSheet.Data;
using _Project_CheatSheet.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace _Project_CheatSheet.Common.CurrentUser
{
    public class CurrentUser : ICurrentUser
    {
        private readonly CheatSheetDbContext context;
        private readonly ClaimsPrincipal user;

        public CurrentUser(
            IHttpContextAccessor httpContext,
            CheatSheetDbContext context)
        {
            this.user = httpContext.HttpContext!.User;
            this.context = context;
        }

        public async Task<User> GetUser()
        {
            var id = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public string GetUserId()
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string GetUserName()
        {
            return user.Identity!.Name!;
        }
    }
}