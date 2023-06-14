using System.ComponentModel.DataAnnotations;

namespace AngularAPI.Models
{
    public class Jobs
    {

        [Key]
        public int JobId { get; set; }
        public string? CompanyName { get; set; }
        public string? JobTitle { get; set; }
        public string? Experience { get; set; }
        public string? Skills { get; set; }
        public string? JobType { get; set; }
        public DateTime JobPostedDate { get; set; }
        public string? CompanyLocation { get; set; }
        public string? JobDescription { get; set; }
    }
}
