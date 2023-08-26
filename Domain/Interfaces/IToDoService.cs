using Shared.DTO;

namespace Domain.Interfaces
{
    public interface IToDoService
    {
        Task<ResponceDto<ToDoDto>> CreateToDo(ToDoCreateDto toDoCreateDto);
        Task<ResponceDto<ToDoDto>> UpdateToDo(ToDoUpdateDto toDoUpdateDto);
        Task<ResponceDto<List<ToDoDto>>> GetToDos();
        Task<ResponceDto<ToDoDto>> GetToDoById(int id);
        Task<ResponceDto<bool>> DeleteToDo(int id);
        Task<ResponceDto<List<ToDoDto>>> GetToDosByUserId(Guid userId);

    }
}
