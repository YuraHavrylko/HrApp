using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    using System.ComponentModel;

    public class LanguageLevel
    {
        [Key]
        public int LanguageLevelId { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Language level name")]
        public string LanguageLevelName { get; set; }
    }
}