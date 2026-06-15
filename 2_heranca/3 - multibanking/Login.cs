using Microsoft.Data.Sqlite;
using BCrypt.Net;

namespace MultiBanking
{
  class Login
  {
    public static ContaBancaria FazerLogin(string connectionString)
    {
      Console.Clear();
      System.Console.WriteLine("insira o nome de titular: ");
      string nome = Console.ReadLine() ?? "";

      System.Console.WriteLine("insira sua senha: ");
      string senha = Console.ReadLine() ?? "";

      using var connection = new SqliteConnection(connectionString);
      connection.Open();
      var command = connection.CreateCommand();

      command.CommandText = @"SELECT Id, TipoConta, Saldo, Senha FROM Contas WHERE Titular = $u";
      command.Parameters.AddWithValue("$u", nome);

      using (var reader = command.ExecuteReader())
      {
        if (reader.Read())
        {
          int id = reader.GetInt32(reader.GetOrdinal("Id"));
          string tipo = reader.GetString(reader.GetOrdinal("TipoConta"));
          decimal saldoBanco = reader.GetDecimal(reader.GetOrdinal("Saldo"));
          string hashArmazenado = reader.GetString(reader.GetOrdinal("Senha"));

          bool senhaValida = BCrypt.Net.BCrypt.Verify(senha, hashArmazenado);

          if (!senhaValida)
          {
            return null;
          }

          return tipo switch
          {
            "Bronze" => new Bronze(nome, saldoBanco),
            "Silver" => new Silver(nome, saldoBanco),
            "Gold" => new Gold(nome, saldoBanco)
          };
        }
        else
        {
          return null;
        }
      }
    }
  }
}