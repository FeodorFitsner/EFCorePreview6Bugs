using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCorePreview6Bugs.Models
{
    public class NuGetFeed
    {
        public int NuGetFeedId { get; set; }

        [ForeignKey("Project")]
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [MaxLength(200)]
        public string FeedId { get; set; }
        public string Name { get; set; }

        public string ApiKey { get; set; }
        public bool PublishingEnabled { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}
