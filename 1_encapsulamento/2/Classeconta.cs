namespace BancoEncapsulamento
{
  public class ContaBancaria
  {
    private int _numeroConta;
    private string _titular;
    private decimal _saldo;

    public ContaBancaria(int numeroConta, string titular)
    {
      _numeroConta = numeroConta;
      _titular = titular;
      _saldo = 0;
    }
    
    public int NumeroConta { get
      {
        return _numeroConta;
      } }

    public string Titular
    {
      get
      {
        return _titular;
      }
      set
      {
        if (string.IsNullOrEmpty(value))
        {
          System.Console.WriteLine("impossível. nome inválido.");
          return;
        }
        else
        {
          _titular = value;
        }
      }
    }

    public decimal Saldo {get
      {
        return _saldo;
      }
    }
    public bool Depositar(decimal valor)
    {
      if (valor < 0)
      {
        return false;
      }
      else
      {
        _saldo = _saldo + valor;
        return true;
      }
    }

    public bool Sacar(decimal valor)
    {
      //rejeita valores negativos, maiores que o saldo,
      //e maiores que o limite de saque
      if (valor < 0 || valor > _saldo)
      {
        return false;
      }
      else
      {
        _saldo = _saldo - valor;
        return true;
      }
    }

    public void ExibirResumo()
    {
      System.Console.WriteLine($"saldo: {_saldo:F2}");
      System.Console.WriteLine($"titular da conta: {_titular}");
      System.Console.WriteLine($"numero da conta: {_numeroConta}");
    }
  }
}