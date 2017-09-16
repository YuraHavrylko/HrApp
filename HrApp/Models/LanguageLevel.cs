using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class LanguageLevel
    {
        [Key]
        public int LanguageLevelId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LanguageLevelName { get; set; }
    }
}