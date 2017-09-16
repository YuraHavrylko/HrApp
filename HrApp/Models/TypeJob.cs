using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class TypeJob
    {
        [Key]
        public int TypeJobId { get; set; }

        [Required]
        [MaxLength(100)]
        public string NameType { get; set; }
    }
}