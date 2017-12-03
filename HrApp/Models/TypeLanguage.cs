using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrApp.Models
{
    using System.ComponentModel;

    public class TypeLanguage
    {
        public int? TypeLanguageId { get; set; }

        [DisplayName("Language name")]
        public string LanguageName { get; set; }
    }
}