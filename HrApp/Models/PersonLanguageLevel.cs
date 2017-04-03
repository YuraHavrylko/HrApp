using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApp.Models
{
    public class PersonLanguageLevel
    {
        [Key]
        public int PersonLanguageLevelId { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }

        [Required]
        [ForeignKey("LanguageId")]
        public int LanguageId { get; set; }

        [Required]
        [ForeignKey("LanguageLevelId")]
        public int LanguageLevelId { get; set; }
    }
}