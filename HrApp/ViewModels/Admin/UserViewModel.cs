namespace HrApp.ViewModels.Admin
{
    using System;

    public class UserViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        
        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }
       
        public bool PhoneNumberConfirmed { get; set; }
       
        public bool TwoFactorEnabled { get; set; }
        
        public DateTime? LockoutEndDateUtc { get; set; }
        
        public bool LockoutEnabled { get; set; }
       
        public int AccessFailedCount { get; set; }
    }
}