using MinimalApi.Dominio.Entidades;

namespace Test.Dominio.Entidades
{
  [TestClass]
  public class VeiculoTest
  {
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
      var veiculo = new Veiculo
      {
        Id = 1,
        Nome = "Kombi",
        Marca = "Volws",
        Ano = 2000
      };

      Assert.AreEqual(1, veiculo.Id);
      Assert.AreEqual("Kombi", veiculo.Nome);
      Assert.AreEqual("Volws", veiculo.Marca);
      Assert.AreEqual(2000, veiculo.Ano);
    }
  }
}