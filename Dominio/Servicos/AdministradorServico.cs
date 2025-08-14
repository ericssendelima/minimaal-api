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
  }
}
