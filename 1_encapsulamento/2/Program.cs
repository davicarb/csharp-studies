using System.Collections;

namespace BancoEncapsulamento
{
  class Program
  {
    static void Main(string[] args)
    {
      System.Console.WriteLine("insira seu nome de titular: ");
      string nome = Console.ReadLine() ?? "";

      while (string.IsNullOrWhiteSpace(nome))
      {
        System.Console.WriteLine("nome incorreto ou nulo. insira novamente: ");
        nome = Console.ReadLine() ?? "";
      }

      Random rand = new Random();
      int numeroContaGerado = rand.Next(1000, 9999);

      var conta = new ContaBancaria(numeroContaGerado, nome);

      int option = 0;

      while (option != 5)
      {
        DisplayMenu();
        option = GetUserOption();

        switch (option)
        {
          case 1:
            conta.ExibirResumo();
            break;
          case 2:
            DepositarMain(conta);
            break;
          case 3:
            SacarMain(conta);
            break;
          case 4:
            System.Console.WriteLine($"o saldo da sua conta é: R${conta.Saldo:F2}");
            break;
          case 5:
            System.Console.WriteLine("saindo...");
            break;
          default:
            Console.WriteLine("opção inválida. Tente novamente.");
            break;
        }

        if (option != 5)
        {
          Console.WriteLine("\npressione qualquer tecla para continuar...");
          Console.ReadKey();
          Console.Clear();
        }
      }
    }

    static void DisplayMenu()
    {
      Console.WriteLine("========== MENU CONTA BANCARIA ==========");
      Console.WriteLine("1 - ver conta (resumo)");
      Console.WriteLine("2 - depositar valor");
      Console.WriteLine("3 - sacar valor");
      Console.WriteLine("4 - ver saldo");
      Console.WriteLine("5 - sair");
      Console.WriteLine("========================");
      Console.Write("Escolha uma opção: ");
    }

    static int GetUserOption()
    {
      if (int.TryParse(Console.ReadLine(), out int option))
      {
        return option;
      }
      return -1;
    }
    static void SacarMain(ContaBancaria conta)
    {
      System.Console.WriteLine("insira um valor para sacar da sua conta:");
      bool valid = decimal.TryParse(Console.ReadLine(), out decimal valor);

      while (!valid)
      {
        System.Console.WriteLine("caracteres inválidos. tente novamente: ");
        valid = decimal.TryParse(Console.ReadLine(), out valor);
      }

      System.Console.WriteLine($"certeza que deseja sacar R${valor:F2} da conta");
      System.Console.WriteLine($"{conta.NumeroConta}\n");
      System.Console.WriteLine("1 para sim, 0 para não.");

      bool validd = int.TryParse(Console.ReadLine(), out int opcao);

      while (!validd || opcao > 2 || opcao < 1)
      {
        System.Console.WriteLine("inválido. tente novamente: ");
        validd = int.TryParse(Console.ReadLine(), out opcao);
      }

      switch (opcao)
      {
        case 1:
          if (conta.Sacar(valor))
          {
            System.Console.WriteLine($"saque no valor de R${valor:F2} feito com sucesso");
            System.Console.WriteLine($"na conta {conta.NumeroConta} de {conta.Titular}!");
            System.Console.WriteLine($"saldo atual na sua conta: R${conta.Saldo}");
          }
          else
          {
            System.Console.WriteLine("impossível efetuar saque.");
            System.Console.WriteLine("valor negativo ou saldo insuficiente.");
            return;
          }
          break;
        case 2:
          return;
      }
    }
    static void DepositarMain(ContaBancaria conta)
    {
      System.Console.WriteLine("insira um valor para depositar:");
      bool valid = decimal.TryParse(Console.ReadLine(), out decimal valor);

      while (!valid)
      {
        System.Console.WriteLine("caracteres inválidos. tente novamente: ");
        valid = decimal.TryParse(Console.ReadLine(), out valor);
      }

      System.Console.WriteLine($"certeza que deseja depositar R${valor:F2} na conta");
      System.Console.WriteLine($"{conta.NumeroConta}\n");
      System.Console.WriteLine("1 para sim, 0 para não.");

      bool validd = int.TryParse(Console.ReadLine(), out int opcao);

      while (!validd || opcao > 2 || opcao < 1)
      {
        System.Console.WriteLine("inválido. tente novamente: ");
        validd = int.TryParse(Console.ReadLine(), out opcao);
      }

      switch (opcao)
      {
        case 1:
          if (conta.Depositar(valor))
          {
            System.Console.WriteLine($"depósito no valor de R${valor:F2} feito com sucesso");
            System.Console.WriteLine($"na conta {conta.NumeroConta} de {conta.Titular}!");
          }
          else
          {
            System.Console.WriteLine("erro inesperado.");
            return;
          }
          break;
        case 2:
          return;
      }
    }
  }
}