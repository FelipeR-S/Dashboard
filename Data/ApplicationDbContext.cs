using DashBoard.Models;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IEncryptionProvider _encrypt;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            _encrypt = new GenerateEncryptionProvider("senha_encrypt_key");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Cria chave para encriptar
            builder.UseEncryption(_encrypt);

            builder.Entity<Cliente>().HasIndex(e => e.Email).IsUnique();
            builder.Entity<NewsLetter>();
            builder.Entity<User>().HasIndex(e => e.Usuario).IsUnique();
            builder.Entity<User>().HasIndex(e => e.Email).IsUnique();
        }
    }
}