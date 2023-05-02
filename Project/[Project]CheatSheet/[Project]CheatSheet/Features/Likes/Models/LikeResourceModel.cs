﻿namespace _Project_CheatSheet.Features.Likes.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LikeResourceModel
    {
        [Required]
        public string ResourceId { get; set; } = null!;

        public bool hasLiked { get; set; }

        public int TotaLikes { get; set; }

    }
}