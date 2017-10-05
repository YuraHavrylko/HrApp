using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApp.Models
{
    public class TypeJob
    {
        [Key]
        public int? PersonTypeJobId { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeJobName { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int? PersonId { get; set; }
    }
}