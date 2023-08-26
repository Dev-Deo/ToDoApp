namespace Shared.DTO
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public int ToDoTaskId { get; set; }
        public ToDoDto ToDoTask { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUserDto ApplicationUser { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
