namespace _Project_CheatSheet.Common.CurrentUser
{
    using System.Security.Claims;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class CurrentUser : ICurrentUser
    {
        private readonly CheatSheetDbContext context;
        private readonly ClaimsPrincipal user;

        public CurrentUser(
            IHttpContextAccessor httpContext,
            CheatSheetDbContext context)
        {
            user = httpContext.HttpContext!.User;
            this.context = context;
        }

        public async Task<User> GetUser()
        {
            var id = GetUserId();
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