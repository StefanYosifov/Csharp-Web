﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _Project_CheatSheet.Infrastructure.Data.GlobalConstants.Topic;
using _Project_CheatSheet.Infrastructure.Data.Models.Base;

namespace _Project_CheatSheet.Infrastructure.Data.Models
{
    public class Topic : Entity
    {

        public Topic()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TopicConstants.NameMaxLength)]
        public string Name { get; set; }

        [MaxLength(TopicConstants.ContentMaxLength)]
        public string Content { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [ForeignKey(nameof(Course))] public Guid CourseId { get; set; }

        public Course Course { get; set; }

        [ForeignKey(nameof(Video))]
        public Guid VideoId { get; set; }
        public virtual Video Video { get; set; } = null!;
    }
}