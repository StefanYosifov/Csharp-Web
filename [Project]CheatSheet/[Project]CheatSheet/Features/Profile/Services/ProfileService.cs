﻿namespace _Project_CheatSheet.Features.Profile.Services
{
    using _Project_CheatSheet.Common.CurrentUser.Interfaces;
    using _Project_CheatSheet.Controllers.Profile.Interfaces;
    using _Project_CheatSheet.Controllers.Profile.Models;
    using _Project_CheatSheet.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ProfileService : IProfileService
    {
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;

        public ProfileService(CheatSheetDbContext context,
                              ICurrentUser currentUserService)
        {
            this.context = context;
            this.currentUserService = currentUserService;
        }

        public async Task<ProfileModel> getProfileData()
        {
            var currentUser = await currentUserService.GetUser();
            string userId = await currentUserService.GetUserId();

            var postCount = await context.Resources.CountAsync(p => p.UserId == userId);
            var likedResourceIds = await context.ResourceLikes
            .Where(rl => rl.UserId == userId)
            .Select(rl => rl.ResourceId)
            .ToListAsync();

            var totalResourceLikes = await context.ResourceLikes
                .Include(rl => rl.Resource)
                .Where(rl => rl.Resource.UserId == userId)
                .Select(rl => rl.ResourceId)
                .CountAsync();


            var totalLikedComments = context.CommentLikes
                .Include(cl => cl.Comment)
                .Where(cl => cl.Comment.UserId == userId)
                .Count();

            var ProfileModel = new ProfileModel()
            {
                PostCount = postCount,
                ResourceLikes = totalResourceLikes,
                CommentLikes = totalLikedComments,
            };

            return ProfileModel;
        }
    }
}
