using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCorePreview6Bugs.Models
{
    public class ProjectAccessRight
    {
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [StringLength(30)]
        public string RightName { get; set; }

        public bool Allowed { get; set; }
    }
}
