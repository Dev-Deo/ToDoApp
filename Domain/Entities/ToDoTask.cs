using Domain.Common;
using Shared.Enums;

namespace Domain.Entities
{
    public class ToDoTask : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
    }
}
