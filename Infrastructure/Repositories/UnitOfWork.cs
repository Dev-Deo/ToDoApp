using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            ToDoTask = new ToDoTaskRepository(_db);
            ToDo = new ToDoRepository(_db);
        }

        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IToDoTaskRepository ToDoTask { get; private set; }
        public IToDoRepository ToDo { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void SaveAsync()
        {
            _db.SaveChangesAsync().GetAwaiter().GetResult();
        }

    }
}
