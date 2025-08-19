using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;

namespace Test.Dominio.Servicos
{
  [TestClass]
  public class AdministradorServicoTest : TesteBaseDb
  {
    private AdministradorServico _servico;
    protected override void InicializarServicos()
    {
      _servico = new AdministradorServico(_contexto);
    }

    [TestMethod]
    public void DeveIncluirNovoAdministrador()
    {
      // Arrange
      var novoAdm = new Administrador { Perfil = "Adm", Email = "aspire@email.com", Senha = "abc" };

      // Act
      var resultado = _servico.Incluir(novoAdm);

      // Assert
      Assert.IsNotNull(resultado);
      Assert.IsTrue(resultado.Id > 0);
      Assert.AreEqual("aspire@email.com", resultado.Email);
    }


    [TestMethod]
    public void DeveListarTodosOsAdministradores()
    {
      // Act
      var lista = _servico.Todos();

      // Assert
      Assert.IsTrue(lista.Count > 0);
      Assert.IsTrue(lista.Any(a => a.Email == "adm@email.com"));
    }
  }
}
