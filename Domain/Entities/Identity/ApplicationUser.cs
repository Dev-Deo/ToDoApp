using Domain.Common;
using Shared.Enums;

namespace Domain.Entities.Identity
{
    public class ApplicationUser : BaseIdentityUserEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int ContactNo { get; set; }
        public List<ToDo> ToDos { get; set; }
    }
}
