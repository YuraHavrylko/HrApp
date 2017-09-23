using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApp.Models
{
    public class PersonTypeJob
    {
        [Key]
        public int PersonTypeJobId { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }

        [Required]
        [ForeignKey("TypeJobName")]
        public string TypeJobName { get; set; }
    }
}