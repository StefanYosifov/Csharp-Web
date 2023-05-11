﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _Project_CheatSheet.Data.Models.Base;
using _Project_CheatSheet.GlobalConstants.Comment;

namespace _Project_CheatSheet.Data.Models
{
    public class Comment : DeletableEntity
    {
        public Comment()
        {
            this.CommentLikes = new HashSet<CommentLike>();
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(CommentConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;

        [ForeignKey(nameof(User))] public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        [ForeignKey(nameof(Resource))] public Guid ResourceId { get; set; }

        public Resource Resource { get; set; } = null!;
        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}