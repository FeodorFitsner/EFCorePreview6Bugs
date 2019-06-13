using EFCorePreview6Bugs.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCorePreview6Bugs
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new DataContext())
            {
                // create database
                context.Database.Migrate();

                // add data
                if (context.Projects.Count() == 0)
                {
                    var project = new Project
                    {
                        Name = "A"
                    };

                    var feed = new NuGetFeed
                    {
                        FeedId = "Feed1",
                        Project = project,
                        Name = "Test Feed 1",
                        Created = DateTime.UtcNow
                    };

                    context.Projects.Add(project);
                    context.NuGetFeeds.Add(feed);
                    context.SaveChanges();
                }

                // tests
                FirstOrDefaultNotImplemented();
                //TheDataIsNull();
                //NoDataExistsForRowColumn();
            }
        }

        // System.NotImplementedException: 'The method or operation is not implemented.'
        static void FirstOrDefaultNotImplemented()
        {
            using (var context = new DataContext())
            {
                var project = context.Projects
                    .Include(p => p.Tags)
                    .Include(p => p.AccessRights)
                    .FirstOrDefault();
            }
        }

        // System.InvalidOperationException: 'The data is NULL at ordinal 5. This method can't be called on NULL values. Check using IsDBNull before calling.'
        static void TheDataIsNull()
        {
            using (var context = new DataContext())
            {
                var projects = context.Projects
                    .Include(p => p.Tags)
                    .Include(p => p.AccessRights)
                    .ToList() // this is to workaround NIE with .FirstOrDefault()
                    .FirstOrDefault();
            }
        }

        // System.InvalidOperationException: 'No data exists for the row/column.'
        static void NoDataExistsForRowColumn()
        {
            using (var context = new DataContext())
            {
                var projects = context.Projects
                    .Include(p => p.NuGetFeeds)
                    .Include(p => p.Tags)
                    .Include(p => p.AccessRights)
                    .ToList() // this is to workaround NIE with .FirstOrDefault()
                    .FirstOrDefault();
            }
        }
    }
}
