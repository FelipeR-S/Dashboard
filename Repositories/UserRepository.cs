using DashBoard.Data;
using DashBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.Repositories
{
    public interface IUserRepository
    {
        Task InitUser();
    }
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IEncryptData _encrypt;
        public UserRepository(ApplicationDbContext context, IEncryptData encrypt) : base(context)
        {
            _encrypt = encrypt;
        }
        public async Task InitUser()
        {
            var admin = await _dbSet.Where(u => u.Matricula == "9999" || u.Usuario == "Admin").SingleOrDefaultAsync();
            if (admin == null)
            {
                var senha = "654321";

                var userAdmin = new User();
                userAdmin.Matricula = "9999";
                userAdmin.Usuario = "Admin";
                userAdmin.Senha = _encrypt.Encrypt(senha);

                await _dbSet.AddAsync(userAdmin);
                await _context.SaveChangesAsync();
            }
        }
    }
}
