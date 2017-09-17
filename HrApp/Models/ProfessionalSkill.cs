using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApp.Models
{
    public class ProfessionalSkill
    {
        [Key]
        public int ProfessionalSkillId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SkillName { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
    }
}