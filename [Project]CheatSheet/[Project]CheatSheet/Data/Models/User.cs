using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _Project_CheatSheet.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Resources = new HashSet<Resource>();
        }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
