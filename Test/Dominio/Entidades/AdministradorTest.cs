using MinimalApi.Dominio.Entidades;

namespace Test.Dominio.Entidades;

[TestClass]
public class AdministradorTest
{
  [TestMethod]
  public void TestarGetSetPropriedades()
  {

    //Arrange -> Criação das variáveis necessárias para as validações
    var adm = new Administrador
    {
      //Act -> Ações - Como setar propriedades
      Id = 1,
      Email = "teste001@teste.com",
      Senha = "teste001",
      Perfil = "Adm"
    };

    //Assert -> Validação dos dados
    Assert.AreEqual(1, adm.Id);
    Assert.AreEqual("teste001@teste.com", adm.Email);
    Assert.AreEqual("teste001", adm.Senha);
    Assert.AreEqual("Adm", adm.Perfil);
  }
}
