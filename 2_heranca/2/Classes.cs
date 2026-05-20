
// Crie um sistema usando Herança e Polimorfismo para representar funcionários de uma empresa.
// Objetivo: A empresa possui vários tipos de funcionários, mas todos compartilham características em comum.

using System.Configuration.Assemblies;

namespace Sisfuncionarios
{
  public class Funcionario
  {
    protected string _nome;
    protected float _salario;

    public string Nome
    {
      get
      {
        return _nome;
      }
      set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          System.Console.WriteLine("erro: entrada inválida.");
          return;
        }
        _nome = value;
      }
    }
    public float Salario
    {
      get
      {
        return _salario;
      }
      set
      {
        if (value < 0)
        {
          System.Console.WriteLine("erro: impossível um salário ser negativo.");
          return;
        }
        _salario = value;
      }
    }

    // construtor da classe base
    public Funcionario(string nome, float salario)
    {
      Nome = nome;
      Salario = salario;
    }
    public virtual float CalcularBonus() { return 0; }
  }

  // classes filhas
  public class Gerente : Funcionario
  {
    protected string _setor;
    public string Setor
    {
      get
      {
        return _setor;
      }
      set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          System.Console.WriteLine("nome do setor inválido.");
          return;
        }
        _setor = value;
      }
    }
    public Gerente(string nome, float salario, string setor)
      : base(nome, salario)
    {
      Setor = setor;
    }

    public override float CalcularBonus()
    {
      float salarioComBonusGer = (this.Salario * 0.20f) + this.Salario;
      return salarioComBonusGer;
    }
  }

  public class Desenvolvedor : Funcionario
  {
    protected string _linguagemPrincipal;
    public string LinguagemPrincipal
    {
      get
      {
        return _linguagemPrincipal;
      }
      set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          System.Console.WriteLine("nome do setor inválido.");
          return;
        }
        _linguagemPrincipal = value;
      }
    }

    public Desenvolvedor(string nome, float salario, string linguagemPrincipal)
  : base(nome, salario)
    {
      LinguagemPrincipal = linguagemPrincipal;
    }

    public override float CalcularBonus()
    {
      float salarioComBonusDev = (this.Salario * 0.15f) + this.Salario;
      return salarioComBonusDev;
    }
  }

  public class Estagiario : Funcionario
  {
    protected string _horasDeEstudo;
    public string HorasDeEstudo
    {
      get
      {
        return _horasDeEstudo;
      }
      set
      {
        if (string.IsNullOrWhiteSpace(value))
        {
          System.Console.WriteLine("horas de estudo inválida.");
          return;
        }
        _horasDeEstudo = value;
      }
    }

    public Estagiario(string nome, float salario, string horasDeEstudo)
  : base(nome, salario)
    {
      HorasDeEstudo = horasDeEstudo;
    }

    public override float CalcularBonus()
    {
      float salarioComBonusEst = (this.Salario * 0.05f) + this.Salario;
      return salarioComBonusEst;
    }
  }
}