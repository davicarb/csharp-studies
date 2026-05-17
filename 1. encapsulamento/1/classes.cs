namespace SisProduto
{
  public class Produto
  {
    private string _nome;

    private decimal _preco;
    private int _estoque;
    public string Nome { get { return _nome; } }
    public decimal Preco { get { return _preco; } }
    public int Estoque
    {
      get { return _estoque; }
      private set { _estoque = value; }
    }

    public Produto(string nome, decimal preco, int quantidade)
    {
      if (string.IsNullOrEmpty(nome))
      {
        System.Console.WriteLine("nome inválido.");
        return;
      }

      if (preco < 0)
      {
        System.Console.WriteLine("preço inválido.");
        return;
      }

      if (quantidade < 0)
      {
        System.Console.WriteLine("quantidade invalida.");
        return;
      }

      _nome = nome;
      _preco = preco;
      _estoque = quantidade;
    }
    public void AdicionarEstoque(int quantidade)
    {
      //adiciona ao estoque (quantidade deve ser positiva)
      if (quantidade < 1)
      {
        System.Console.WriteLine("quantidade inválida.");
        return;
      }
      _estoque += quantidade;
    }

    public void VenderProduto(int quantidade)
    {
      //subtrai do estoque (não pode vender mais do que tem)
      if (quantidade > _estoque)
      {
        System.Console.WriteLine("impossível vender mais do que tem.");
        return;
      }
      _estoque -= quantidade;
    }

    public void ExibirInfo()
    {
      //mostra os dados do produto no console
      System.Console.WriteLine("=== Produto ===");
      System.Console.WriteLine($"Nome: {_nome}");
      System.Console.WriteLine($"Preço: {_preco:F2}");
      System.Console.WriteLine($"Estoque: {_estoque}");
    }
  }
}