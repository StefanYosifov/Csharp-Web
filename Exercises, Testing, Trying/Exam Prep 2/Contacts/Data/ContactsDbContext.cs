﻿using Contacts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ContactsDbContext : IdentityDbContext<ApplicationUser>
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
          
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public virtual DbSet<ApplicationUserContact> ApplicationUserContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ApplicationUserContact>()
                .HasKey(x => new
                {
                    x.ApplicationUserId,x.ContactId
                });

            builder
             .Entity<Contact>()
             .HasData(new Contact()
             {
                 Id = 1,
                 FirstName = "Bruce",
                 LastName = "Wayne",
                 PhoneNumber = "+359881223344",
                 Address = "Gotham City",
                 Email = "imbatman@batman.com",
                 Website = "www.batman.com"
             });



            base.OnModelCreating(builder);
        }
    }
}