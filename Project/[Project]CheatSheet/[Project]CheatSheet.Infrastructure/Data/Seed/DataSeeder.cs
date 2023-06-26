namespace _Project_CheatSheet.Infrastructure.Data.Seed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models.Enums;

    internal class DataSeeder
    {

        internal static ModelBuilder SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "1", Name = ApplicationRolesEnum.Administrator.ToString(), NormalizedName = ApplicationRolesEnum.Administrator.ToString().ToUpper() },
                new IdentityRole() { Id = "2", Name = ApplicationRolesEnum.Moderator.ToString(), NormalizedName = ApplicationRolesEnum.Moderator.ToString().ToUpper()},
                new IdentityRole(){Id = "3",Name =ApplicationRolesEnum.User.ToString(),NormalizedName = ApplicationRolesEnum.User.ToString().ToUpper()}
            );
            return modelBuilder;
        }

    }
}
