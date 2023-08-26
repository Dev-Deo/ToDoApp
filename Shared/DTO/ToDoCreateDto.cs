namespace Shared.DTO
{
    public class ToDoCreateDto
    {
        public int ToDoTaskId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
