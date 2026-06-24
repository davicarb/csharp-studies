using Microsoft.Data.Sqlite;

namespace MultiBanking
{
  class Database
  {
    public static void InicializaDb(string connectionString)
    {
      using var connection = new SqliteConnection(connectionString);
      connection.Open();
      var command = connection.CreateCommand();

      command.CommandText = @"CREATE TABLE IF NOT EXISTS Contas
      (Id INTEGER PRIMARY KEY AUTOINCREMENT,
      TipoConta TEXT NOT NULL,
      Titular TEXT NOT NULL,
      Senha TEXT NOT NULL,
      Saldo DECIMAL NOT NULL)";

      command.ExecuteNonQuery();
    }
  }
}