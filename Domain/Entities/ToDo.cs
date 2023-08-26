using Domain.Common;
using Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ToDo:BaseEntity
    {
        public int ToDoTaskId { get; set; }
        [ForeignKey("ToDoTaskId")]
        public ToDoTask ToDoTask { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

    }
}
