using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;

namespace MinimalApi.Infraestrutura.Db
{
  public class DbContexto(DbContextOptions<DbContexto> options) : DbContext(options)
  {
    public DbSet<Adiministrador> Administradores { get; set; } = default!;

  }
}
