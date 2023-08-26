namespace Shared.DTO
{
    public class ToDoUpdateDto
    {
        public int Id { get; set; }
        public int ToDoTaskId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
