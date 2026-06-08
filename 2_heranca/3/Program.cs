using System.Data;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;

namespace MultiBanking
{
  class Program
  {
    static void Main(string[] args)
    {
      string connectionString = "Data source=contas.db";
      Database.InicializaDb(connectionString);

      bool rodandoLogin = true;
      bool runningAuthenticated = false;
      ContaBancaria contaLogada = null;

      while (rodandoLogin)
      {

        Console.Clear();
        System.Console.WriteLine("=== multi-banking login page ===");
        System.Console.WriteLine("1. fazer login");
        System.Console.WriteLine("2. fazer cadastro");
        System.Console.WriteLine("3. sair");

        bool valid = int.TryParse(Console.ReadLine(), out int option);

        while (!valid || option < 1 || option > 3)
        {
          System.Console.WriteLine("entrada inválida.");
          System.Console.WriteLine("insira novamente: ");
          valid = int.TryParse(Console.ReadLine(), out option);
        }

        switch (option)
        {
          case 1:
            contaLogada = Login.FazerLogin(connectionString);
            if (contaLogada == null)
            {
              System.Console.WriteLine("falha no login.");
              Console.ReadKey();
            }
            else
            {
              System.Console.WriteLine("autenticado com sucesso!");
              runningAuthenticated = true;
              Console.ReadKey();
            }
            break;

          case 2:
            Cadastro.CadastrarConta(connectionString);
            break;

          case 3:
            rodandoLogin = false;
            break;
        }

        while (runningAuthenticated)
        {
          Console.Clear();
          decimal saldoAtual = contaLogada.ConsultaSaldo();
          decimal limiteConta = contaLogada.ConsultaLimite();
          string titularConta = contaLogada.Titular;

          System.Console.WriteLine("=== multi-banking authenticated page ===\n");
          System.Console.WriteLine($"titular da conta: {contaLogada.Titular}");
          System.Console.WriteLine($"saldo da conta: {saldoAtual:F2}");
          System.Console.WriteLine($"limite da conta (crédito): {limiteConta:F2}\n");
          System.Console.WriteLine("1. efetuar um depósito");
          System.Console.WriteLine("2. transferência eletrônica");
          System.Console.WriteLine("3. efetuar encerramento da conta");
          System.Console.WriteLine("4. sair da conta");

          bool validAuth = int.TryParse(Console.ReadLine(), out int optionAuth);

          while (!validAuth || option < 1 || option > 4)
          {
            System.Console.WriteLine("entrada inválida.");
            System.Console.WriteLine("insira novamente: ");
            validAuth = int.TryParse(Console.ReadLine(), out optionAuth);
          }

          switch (optionAuth)
          {
            case 1:
              System.Console.WriteLine("insira o valor que deseja depositar na sua conta: ");
              bool validValor = int.TryParse(Console.ReadLine(), out int valor);

              while (!validAuth)
              {
                System.Console.WriteLine("valor inválido.");
                System.Console.WriteLine("insira novamente: ");
                validValor = int.TryParse(Console.ReadLine(), out valor);
              }
              try
              {
                contaLogada.Depositar(valor);

                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "UPDATE Contas SET Saldo = Saldo + $v WHERE Titular = $t";
                command.Parameters.AddWithValue("$v", valor);
                command.Parameters.AddWithValue("$t", titularConta);
                command.ExecuteNonQuery();

                System.Console.WriteLine($"valor de R${valor:F2} depositado com sucesso!");
                Console.ReadKey();
                connection.Close();
              }
              catch (ArgumentException)
              {
                System.Console.WriteLine("valor inválido para depósito.");
              }
              Console.ReadKey();
              break;

            case 2:
              System.Console.WriteLine("insira o nome do titular para o qual quer transferir: ");
              string titularTransferir = Console.ReadLine() ?? "";

              while (titularTransferir.Length < 0 || string.IsNullOrWhiteSpace(titularTransferir))
              {
                System.Console.WriteLine("entrada inválida. insira novamente: ");
                titularTransferir = Console.ReadLine() ?? "";
              }

              try
              {
                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "SELECT Id FROM Contas WHERE Titular = $tInput";
                command.Parameters.AddWithValue("$tInput", titularTransferir);

                var resultado = command.ExecuteScalar();

                if (resultado == null)
                {
                  System.Console.WriteLine("erro: o titular informado não existe.");
                  break;
                }
                Console.ReadKey();
              }
              catch
              {
                System.Console.WriteLine("erro inesperado.");
                Console.ReadKey();
              }

              System.Console.WriteLine($"titular encontrado: {titularTransferir}");
              System.Console.WriteLine("insira o valor que quer transferir: ");
              bool validTransferir = int.TryParse(Console.ReadLine(), out int valorTransferir);

              while (!validTransferir)
              {
                System.Console.WriteLine("valor inválido.");
                System.Console.WriteLine("insira novamente: ");
                validTransferir = int.TryParse(Console.ReadLine(), out valorTransferir);
              }

              if (valorTransferir > saldoAtual)
              {
                System.Console.WriteLine("impossível efetuar transferência. saldo insuficiente.");
                System.Console.WriteLine($"seu saldo atual: R${saldoAtual:F2}");
                break;
              }

              try
              {
                decimal novoSaldo = contaLogada.Transferir(valorTransferir);

                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = @"UPDATE Contas SET Saldo = Saldo + $v WHERE Titular = $tt";
                command.Parameters.AddWithValue("$v", valorTransferir);
                command.Parameters.AddWithValue("$tt", titularTransferir);

                command.ExecuteNonQuery();
                command.Parameters.Clear();

                command.CommandText = @"UPDATE Contas SET Saldo = $novoSaldo WHERE Titular = $t";
                command.Parameters.AddWithValue("$novoSaldo", novoSaldo);
                command.Parameters.AddWithValue("$t", titularConta);

                command.ExecuteNonQuery();
              }

              catch
              {
                System.Console.WriteLine("erro inesperado na transferência. tente novamente.");
              }

              break;

            case 3:
              break;

            case 4:
              runningAuthenticated = false;
              break;
          }

          Console.ReadKey();
        }
      }
    }
  }
}