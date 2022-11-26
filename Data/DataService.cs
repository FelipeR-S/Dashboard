using Microsoft.EntityFrameworkCore;

namespace DashBoard.Data
{
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _context;

        public DataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InitDB()
        {
            await _context.Database.MigrateAsync();
        }
    }
}
