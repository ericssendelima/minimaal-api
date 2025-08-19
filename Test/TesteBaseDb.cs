using Microsoft.EntityFrameworkCore;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Infraestrutura.Db;


namespace Test;
public abstract class TesteBaseDb
{
  protected DbContexto _contexto;

  [TestInitialize]
  public void Setup()
  {
    try
    {
      Console.WriteLine("Iniciando setup do teste...");

      // Nome único para o banco a cada execução
      var dbName = $"MinimaalApiDbTest_{Guid.NewGuid()}";
      var connectionString = $"Server=(LocalDB)\\MSSQLLocalDB;Database={dbName};Trusted_Connection=True;MultipleActiveResultSets=true";

      var options = new DbContextOptionsBuilder<DbContexto>()
          .UseSqlServer(connectionString)
          .EnableSensitiveDataLogging() // Útil para debug
          .LogTo(Console.WriteLine) // Ver logs SQL no console
          .Options;

      _contexto = new DbContexto(options);

      Console.WriteLine($"Criando banco de dados {dbName}...");
      _contexto.Database.EnsureCreated(); // Cria o banco sem precisar de migrations

      Console.WriteLine("Banco criado! Adicionando dados de teste...");
      // Seed de exemplo
      _contexto.Administradores.Add(new Administrador
      {
        Perfil = "Adm",
        Email = "adm@email.com",
        Senha = "123"
      });
      _contexto.SaveChanges();

       InicializarServicos();

      Console.WriteLine("Setup concluído com sucesso!");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"ERRO NO SETUP: {ex.Message}");
      Console.WriteLine(ex.StackTrace);
      throw; // Re-lança para o MSTest saber que falhou
    }
  }

   // Método para classes derivadas inicializarem serviços
    protected virtual void InicializarServicos() 
    { 
        // Vazio na classe base, implementado nas classes filhas
    }

  [TestCleanup]
  public void Cleanup()
  {
    _contexto.Dispose();
  }

}