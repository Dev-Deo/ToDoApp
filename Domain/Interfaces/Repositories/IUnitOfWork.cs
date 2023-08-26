namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUser { get; }
        IToDoTaskRepository ToDoTask { get; }
        IToDoRepository ToDo { get; }
        void SaveAsync();
    }
}
