using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos
{
  public class AdministradorServico(DbContexto contexto) : IAdministradorServico
  {
    private readonly DbContexto _contexto = contexto;

    public Administrador? Login(LoginDTO loginDTO)
    {
      var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

      return adm;
    }

    public Administrador Incluir(Administrador administrador)
    {
      _contexto.Administradores.Add(administrador);
      _contexto.SaveChanges();

      return administrador;

    }

    public List<Administrador> Todos(int? pagina = 1)
    {
      var query = _contexto.Administradores.AsQueryable();

      const int itensPorPagina = 10;

      if (pagina != null)
      {
        query = query.Skip(((int)pagina - 1) * itensPorPagina).Take(itensPorPagina);
      }

      return query.ToList();
    }

    public Administrador? BuscaPorId(int id)
    {
      return _contexto.Administradores.Find(id);
    }
  }
}
