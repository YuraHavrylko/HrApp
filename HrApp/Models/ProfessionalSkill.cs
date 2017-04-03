using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class ProfessionalSkill
    {
        [Key]
        public int ProfessionalSkillId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SkillName { get; set; }
    }
}