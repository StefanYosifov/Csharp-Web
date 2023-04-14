namespace _Project_CheatSheet.Data
{
    using _Project_CheatSheet.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CheatSheetDbContent : IdentityDbContext<User>
    {
        public CheatSheetDbContent(DbContextOptions<CheatSheetDbContent> options)
            : base(options)
        {


        }
    }
}