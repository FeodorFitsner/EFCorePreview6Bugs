using System;
using System.Collections.Generic;
using System.Text;

namespace EFCorePreview6Bugs.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NuGetFeed> NuGetFeeds { get; set; }

        public virtual ICollection<ProjectTag> Tags { get; set; }

        public virtual ICollection<ProjectAccessRight> AccessRights { get; set; }
    }
}
