﻿using _Project_CheatSheet.Infrastructure.Data.Models;

namespace _Project_CheatSheet.Features.Topics.Models
{
    public class TopicRespondModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string CourseName { get; set; }

        public string VideoId { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }
    }
}
