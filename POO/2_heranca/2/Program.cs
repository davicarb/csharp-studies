
// Crie um sistema usando Herança e Polimorfismo para representar funcionários de uma empresa.
// Objetivo: A empresa possui vários tipos de funcionários, mas todos compartilham características em comum.

namespace Sisfuncionarios
{
  class Program
  {
    static void Main(string[] args)
    {
      // inicializando a lista de funcionarios...
      var funcionarios = new List<Funcionario>();

      // inicializando a instância do gerente...
      System.Console.WriteLine("insira o nome do gerente: ");
      string nomeGerente = Console.ReadLine() ?? "";

      System.Console.WriteLine("insira o salário do gerente: ");

      bool valid = float.TryParse(Console.ReadLine(), out float salarioGerente);

      while (!valid)
      {
        System.Console.WriteLine("inválido. insira novamente: ");
        valid = float.TryParse(Console.ReadLine(), out salarioGerente);
      }

      System.Console.WriteLine("insira o setor do gerente: ");
      string setorGerente = Console.ReadLine() ?? "";

      var gerente = new Gerente(nomeGerente, salarioGerente, setorGerente);
      System.Console.WriteLine(gerente.Nome);
      System.Console.WriteLine(gerente.Salario);
      System.Console.WriteLine(gerente.Setor);

      // inicializando um desenvolvedor...
      System.Console.WriteLine("insira o nome do desenvolvedor: ");
      string nomeDev = Console.ReadLine() ?? "";

      System.Console.WriteLine("insira o salário do desenvolvedor: ");

      bool validd = float.TryParse(Console.ReadLine(), out float salarioDev);

      while (!validd)
      {
        System.Console.WriteLine("inválido. insira novamente: ");
        validd = float.TryParse(Console.ReadLine(), out salarioDev);
      }

      System.Console.WriteLine("insira a linguagem principal do desenvolvedor : ");
      string linguagem = Console.ReadLine() ?? "";

      var dev = new Desenvolvedor(nomeDev, salarioDev, linguagem);
      System.Console.WriteLine(dev.Nome);
      System.Console.WriteLine(dev.Salario);
      System.Console.WriteLine(dev.LinguagemPrincipal);

      //inicializando um estagiário...
      System.Console.WriteLine("insira o nome do estagiário: ");
      string nomeEst = Console.ReadLine() ?? "";

      System.Console.WriteLine("insira o salário do desenvolvedor: ");

      bool validdd = float.TryParse(Console.ReadLine(), out float salarioEstagiario);

      while (!validdd)
      {
        System.Console.WriteLine("inválido. insira novamente: ");
        validdd = float.TryParse(Console.ReadLine(), out salarioEstagiario);
      }

      System.Console.WriteLine("insira as horas de estudo necessárias do estagiário: ");
      string horasDeEstudo = Console.ReadLine() ?? "";

      var est = new Estagiario(nomeEst, salarioEstagiario, horasDeEstudo);
      System.Console.WriteLine(est.Nome);
      System.Console.WriteLine(est.Salario);
      System.Console.WriteLine(est.HorasDeEstudo);


      funcionarios.Add(gerente);
      funcionarios.Add(dev);
      funcionarios.Add(est);

      foreach (var funcionario in funcionarios)
      {
        float salarioComBonus = funcionario.CalcularBonus();
        System.Console.WriteLine($"o salário com bônus de {funcionario.Nome}, com um salário de {funcionario.Salario}, é de R${salarioComBonus:F2}!");
      }
      
    }
  }
}