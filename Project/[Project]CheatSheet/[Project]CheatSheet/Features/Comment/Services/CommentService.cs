﻿namespace _Project_CheatSheet.Features.Comment.Services
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Exceptions;
    using Common.GlobalConstants.Comment;
    using Common.UserService.Interfaces;

    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CommentService : ICommentService
    {
        private readonly CheatSheetDbContext context;
        private readonly ICurrentUser currentUserService;
        private readonly IMapper mapper;

        public CommentService(
            CheatSheetDbContext context,
            ICurrentUser currentUserService, 
            IMapper mapper)
        {
            this.context = context;
            this.currentUserService = currentUserService;
            this.mapper = mapper;
        }

        public async Task<string> CreateAComment(InputCommentModel comment)
        {
            if (comment == null)
            {
                throw new ServiceException(CommentMessages.OnEmptyComment);
            }
            
            var resource = await GetResource(comment.ResourceId);
            if (resource == null)
            {
                throw new ServiceException(CommentMessages.OnUnsuccessfulPostComment);
            }

            var userId = currentUserService.GetUserId();

            var dbComment = new Comment
            {
                UserId = userId,
                Content = comment.Content,
                ResourceId = Guid.Parse(comment.ResourceId)
            };

            await context.Comments.AddAsync(dbComment);
            await context.SaveChangesAsync();
            return CommentMessages.OnSuccessfulPostComment;
        }

        public async Task<string> EditComment(string id, EditCommentModel commentModel)
        {
            var currentUserId = currentUserService.GetUserId();
            var comment = await context.Comments.FindAsync(Guid.Parse(id));

            try
            {
                context.Entry(comment).CurrentValues.SetValues(commentModel);
                await context.SaveChangesAsync();
                return CommentMessages.OnSuccessfulEditComment;
            }
            catch (DbUpdateException)
            {
                return CommentMessages.OnUnsuccessfulEditComment!;
            }
        }

        public async Task<string> DeleteComment(string id)
        {
            var comment = await context.Comments.FindAsync(Guid.Parse(id));
            var userId = currentUserService.GetUserId();

            if (comment == null || comment.UserId != userId || comment.IsDeleted)
            {
                return CommentMessages.OnUnsuccessfulDeleteComment;
            }

            context.Remove(comment);
            await context.SaveChangesAsync();
            return CommentMessages.OnSuccessfulDeleteComment;
        }

        public async Task<IEnumerable<CommentModel>> GetCommentsFromResource(string resourceId)
        {
            if (resourceId.Length != 36)
            {
                return Enumerable.Empty<CommentModel>();
            }

            var userId = currentUserService.GetUserId();

            IEnumerable<CommentModel> comments = await context.Comments
                .OrderBy(c => c.CreatedOn)
                .ProjectTo<CommentModel>(mapper.ConfigurationProvider)
                .Where(c => c.ResourceId == resourceId).ToArrayAsync();

            foreach (var comment in comments)
            {
                comment.HasLiked = comment.CommentLikes.Select(cl => cl.UserId).Any(c => c == userId);
            }
            return comments;
        }

        private async Task<Resource?> GetResource(string resourceId)
        {
            var resource = await context.Resources.FindAsync(resourceId);
            return resource;
        }
    }
}