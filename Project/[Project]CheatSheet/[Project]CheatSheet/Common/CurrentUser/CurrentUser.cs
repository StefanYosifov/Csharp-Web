namespace _Project_CheatSheet.Common.CurrentUser
{
    using _Project_CheatSheet.Common.CurrentUser.Interfaces;
    using _Project_CheatSheet.Data;
    using _Project_CheatSheet.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class CurrentUser : ICurrentUser
    {
        private readonly ClaimsPrincipal user;
        private readonly CheatSheetDbContext context;

        public CurrentUser(IHttpContextAccessor httpContext,
                            CheatSheetDbContext context)
        {
            this.user = httpContext.HttpContext.User;
            this.context = context;
        }

        public async Task<User> GetUser()
        {
            var id = this.user.FindFirstValue(ClaimTypes.NameIdentifier);
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public string GetUserId()
        {
            return this.user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string GetUserName()
        {
            return this.user.Identity!.Name!;
        }
    }
}
