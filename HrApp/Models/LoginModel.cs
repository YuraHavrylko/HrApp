namespace HrApp.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}