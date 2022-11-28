using DashBoard.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.Data
{
    public class DataService : IDataService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;

        public DataService(ApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task InitDB()
        {
            await _context.Database.MigrateAsync();
            await _userRepository.InitUser();
        }
    }
}
