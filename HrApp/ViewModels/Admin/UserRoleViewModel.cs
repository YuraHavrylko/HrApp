namespace HrApp.ViewModels.Admin
{
    using System.Collections.Generic;

    public class UserRoleViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<RoleViewModel> Roles { get; set; }

        public List<RoleViewModel> AllRoles { get; set; }
    }
}