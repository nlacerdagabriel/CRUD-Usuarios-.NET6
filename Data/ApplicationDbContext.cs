using Microsoft.EntityFrameworkCore;
using usuario.Models;

namespace usuario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        ) :
            base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var usuario = modelBuilder.Entity<Usuario>();

            usuario.HasKey(x => x.Id);
            usuario.ToTable("usuarios");
            
            usuario
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.DataNascimento).HasColumnName("data_nascimento");


        }
    }
}
