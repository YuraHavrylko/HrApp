using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApp.Models
{
    public class PersonSkill
    {
        [Key]
        public int PersonSkillId { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }

        [Required]
        [ForeignKey("ProfessionalSkillId")]
        public int ProfessionalSkillId { get; set; }
    }
}