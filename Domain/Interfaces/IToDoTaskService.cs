using Shared.DTO;

namespace Domain.Interfaces
{
    public interface IToDoTaskService
    {
        Task<ResponceDto<ToDoTaskDto>> CreateToDoTask(ToDoTaskCreateDto toDoTaskCreateDto);
        Task<ResponceDto<ToDoTaskDto>> UpdateToDoTask(ToDoTaskUpdateDto toDoTaskUpdateDto);
        Task<ResponceDto<ToDoTaskDto>> GetToDoTaskById(int id);
        Task<ResponceDto<List<ToDoTaskDto>>> GetToDoTasks();
        Task<ResponceDto<bool>> DeleteToDoTask(int id);
    }
}
