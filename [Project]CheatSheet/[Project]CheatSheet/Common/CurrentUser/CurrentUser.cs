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

        private readonly IHttpContextAccessor httpContext;
        private readonly CheatSheetDbContext context;

        public CurrentUser(IHttpContextAccessor httpContext,
                            CheatSheetDbContext context)
        {
            this.httpContext = httpContext;
            this.context = context;
        }

        public async Task<User> GetUser()
        {
            var id = httpContext.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<string> GetUserId()
        {
            return httpContext.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
