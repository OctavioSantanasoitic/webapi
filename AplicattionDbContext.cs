using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class AplicattionDbContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }

    public DbSet<Diretor> Diretores { get; set; }

    public AplicattionDbContext(DbContextOptions<AplicattionDbContext> options) : base(options)
    {

    }
}