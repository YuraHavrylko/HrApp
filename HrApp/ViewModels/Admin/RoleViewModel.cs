namespace HrApp.ViewModels.Admin
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            RoleViewModel person = (RoleViewModel)obj;
            return (this.Id == person.Id);
        }
    }
}