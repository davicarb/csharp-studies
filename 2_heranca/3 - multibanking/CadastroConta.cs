using Microsoft.Data.Sqlite;

namespace MultiBanking
{
  class Cadastro
  {
    public static void CadastrarConta(string connectionString)
    {
      Console.Clear();
      System.Console.WriteLine("=== cadastro de contas no multi-banking ===");
      System.Console.WriteLine("nome do titular da conta: ");
      string nome = Console.ReadLine() ?? "";

      while (nome == null)
      {
        System.Console.WriteLine("nome de usuário inválido.");
        System.Console.WriteLine("tente novamente: ");
        nome = Console.ReadLine() ?? "";
      }

      System.Console.WriteLine("crie uma senha para sua conta (mínimo 7 caracteres): ");

      string senha = Console.ReadLine() ?? "";

      while (senha == null)
      {
        System.Console.WriteLine("senha inválida.");
        System.Console.WriteLine("tente novamente: ");
        senha = Console.ReadLine() ?? "";
      }

      System.Console.WriteLine("insira o tipo da conta que quer criar (1, 2 ou 3): ");
      System.Console.WriteLine("1. Conta bronze (Limite inicial de R$1500,00 de crédito, anuidade: R$ 0)");
      System.Console.WriteLine("2. Conta Silver (Limite inicial de R$3000,00 de crédito, anuidade: R$ 499,90)");
      System.Console.WriteLine("3. Conta Gold (Limite inicial de R$7000,00 de crédito, anuidade: R$ 899,90)");
      System.Console.WriteLine("insira o tipo da conta que quer criar (1, 2 ou 3): ");

      bool valid = int.TryParse(Console.ReadLine(), out int opcaoConta);

      while (!valid || opcaoConta < 1 || opcaoConta > 3)
      {
        System.Console.WriteLine("entrada inválida. insira corretamente: ");
        valid = int.TryParse(Console.ReadLine(), out opcaoConta);
      }

      string tipoConta = "";

      switch (opcaoConta)
      {
        case 1:
          tipoConta = "Bronze";
          break;
        case 2:
          tipoConta = "Silver";
          break;
        case 3:
          tipoConta = "Gold";
          break;
      }

      using var connection = new SqliteConnection(connectionString);
      connection.Open();
      var command = connection.CreateCommand();

      command.CommandText = @"INSERT INTO Contas (Titular, Senha, TipoConta, Saldo)
      VALUES ($u, $s, $t, 0)";
      command.Parameters.AddWithValue("$u", nome);
      command.Parameters.AddWithValue("$s", senha);
      command.Parameters.AddWithValue("$t", tipoConta);

      command.ExecuteNonQuery();

      System.Console.WriteLine("conta cadastrada com sucesso!");
      Console.ReadKey();
    }
  }
}