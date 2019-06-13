using EFCorePreview6Bugs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace EFCorePreview6Bugs
{
    public class DataContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTag> ProjectTags { get; set; }
        public DbSet<ProjectAccessRight> ProjectAccessRights { get; set; }
        public DbSet<NuGetFeed> NuGetFeeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string binPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string databasePath = Path.Combine(binPath, "test.db");

            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectAccessRight>().HasKey(e => new { e.ProjectId, e.RightName });
        }
    }
}
