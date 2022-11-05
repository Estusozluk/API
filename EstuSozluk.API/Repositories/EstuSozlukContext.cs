﻿using System;
using EstuSozluk.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EstuSozluk.API.Repositories
{
    public class EstuSozlukContext : DbContext
    {
        public EstuSozlukContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<User>()
                .HasKey(e => e.userid);

            modelBuilder.Entity<User>()
            .HasMany(e => e.entries)
            .WithOne(t => t.User);

            modelBuilder.Entity<User>()
            .HasOne(e => e.permissions)
            .WithOne(t => t.user)
            .HasForeignKey<Permissions>(q => q.userroleid)
            .HasConstraintName("FK_UserRole")
            .HasPrincipalKey<User>(z => z.userroleId);

            modelBuilder.Entity<Followships>()
                .HasKey(e => new { e.follower, e.followed });

            modelBuilder.Entity<Followships>()
                .HasOne<User>(e => e.User1)
                .WithMany(t => t.Following)
                .HasForeignKey(et => et.follower);

            modelBuilder.Entity<Followships>()
                .HasOne(e => e.User2)
                .WithMany(t => t.Followed)
                .HasForeignKey(et => et.followed);

            

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Followships> Followships { get; set; }

    }
}
