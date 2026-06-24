namespace MultiBanking
{
  public abstract class ContaBancaria
  {
    protected int _idUsuario;
    protected decimal _saldo;
    protected decimal _limiteCredito;
    protected string _titular;

    public string Titular
    {
      get
      {
        return _titular;
      }
      set
      {
        if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
        {
          throw new ArgumentException();
        }
        _titular = value;
      }
    }

    public decimal Depositar(decimal valor)
    {
      if (valor <= 0)
      {
        throw new ArgumentException();
      }
      _saldo = _saldo + valor;
      return valor;
    }

    public decimal ConsultaSaldo()
    {
      return _saldo;
    }

    public decimal ConsultaLimite() {
      return _limiteCredito;
    }

    public decimal Transferir(decimal valor)
    { 
      this._saldo = this._saldo - valor;
      return this._saldo;
    }

    protected ContaBancaria(string titular, decimal saldo, decimal limite)
    {
      Titular = titular;
      _saldo = saldo;
      _limiteCredito = limite;
    }
  }

  public class Bronze : ContaBancaria
  {
    public Bronze(string titular, decimal saldo) : base(titular, saldo, 1500) 
    {
    }
  }
  public class Silver : ContaBancaria
  {
    public Silver(string titular, decimal saldo) : base(titular, saldo, 3500)
    {
    }
  }
  public class Gold : ContaBancaria
  {
    public Gold(string titular, decimal saldo) : base(titular, saldo, 7000)
    {
    }
  }
}