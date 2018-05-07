namespace HrApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AspNetRoleClaims")]
    public class RoleClaim
    {
        [Key]
        public int Id { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public string RoleId { get; set; }
    }
}