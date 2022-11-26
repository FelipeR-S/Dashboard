using DashBoard.Data;
using DashBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
    }
}
