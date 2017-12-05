using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrApp.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class TypeLanguage
    {
        public int? TypeLanguageId { get; set; }

        [Required]
        [DisplayName("Language name")]
        public string LanguageName { get; set; }
    }
}