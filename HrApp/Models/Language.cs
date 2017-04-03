using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }

        [Required]
        [MaxLength(50)]
        public string LanguageName { get; set; }
    }
}