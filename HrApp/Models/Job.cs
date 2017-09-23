using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApp.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        [MaxLength(200)]
        public string JobName { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
    }
}