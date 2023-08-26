using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ToDoTaskRepository : Repository<ToDoTask>, IToDoTaskRepository
    {
        private readonly ApplicationDbContext _db;
        public ToDoTaskRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
