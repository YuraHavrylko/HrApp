namespace HrApp.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class RegisterModel
    {
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords not match")]
        [DataType(DataType.Password)]
        [DisplayName("Retype password")]
        public string PasswordConfirm { get; set; }
    }
}