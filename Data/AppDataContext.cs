using Filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace AppDataContext;

public class AppDbContext : DbContext {
    public DbSet<FilmeModel> FilmeModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseSqlServer(@"Server=DESKTOP-H7797U1\SQLEXPRESS;
                             Database=FilmesOnline;
                             Integrated Security=True;
                             Encrypt=False");
    }
}