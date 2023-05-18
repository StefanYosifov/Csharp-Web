﻿using System;
using System.Collections.Generic;

namespace _Project_CheatSheet.Infrastructure.Models
{
    public partial class User
    {
        public User()
        {
            Resources = new HashSet<Resource>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
