using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace github.Domain.DTO
{
    public class CreateRepositoryDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Homepage { get; set; }
        public bool? Private { get; set; }
        public bool? HasIssues { get; set; }
        public bool? HasProjects { get; set; }
        public bool? HasWiki { get; set; }
        public int? TeamId { get; set; }
        public bool? AutoInit { get; set; }
        public string? GitignoreTemplate { get; set; }
        public string? LicenseTemplate { get; set; }
        public bool? AllowSquashMerge { get; set; }
        public bool? AllowMergeCommit { get; set; }
        public bool? AllowRebaseMerge { get; set; }
        public bool? DeleteBranchOnMerge { get; set; }
        public bool? HasDownloads { get; set; }
        public bool? IsTemplate { get; set; }
    }
}
