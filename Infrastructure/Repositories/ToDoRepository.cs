using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        private readonly ApplicationDbContext _db;
        public ToDoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
