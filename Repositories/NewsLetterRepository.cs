using DashBoard.Data;
using DashBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.Repositories
{
    public interface INewsLetterRepository 
    {
        Task<string> CadastraEmail(NewsLetter email);
    }
    public class NewsLetterRepository : BaseRepository<NewsLetter>, INewsLetterRepository
    {
        public NewsLetterRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<string> CadastraEmail(NewsLetter email)
        {
            // verifica se cliente já existe no DB
            var emailDB = await _dbSet.Where(c => c.Email == email.Email).SingleOrDefaultAsync();

            if (emailDB == null)
            {
                // Grava cliente no banco de dados
                await _dbSet.AddAsync(email);
                await _context.SaveChangesAsync();
                return "Cadastro concluído";
            }
            else return "E-mail já consta nas bases de dados.";
        }
    }
}
