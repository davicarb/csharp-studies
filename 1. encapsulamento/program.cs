namespace SisProduto
{
  class Program
  {
    static void Main(string[] args)
    {
      System.Console.WriteLine("insira o nome do seu produto: ");
      string nome = Console.ReadLine() ?? "";

      System.Console.WriteLine("insira o valor do seu produto: ");
      bool valid = decimal.TryParse(Console.ReadLine(), out decimal preco);

      System.Console.WriteLine("insira a quantidade de produtos deste produto: ");
      bool valid2 = int.TryParse(Console.ReadLine(), out int qtd);

      var produto = new Produto(nome, preco, qtd);
      produto.ExibirInfo();

      System.Console.WriteLine("insira a quantidade de estoque que quer adicionar: ");
      bool valid3 = int.TryParse(Console.ReadLine(), out int qtd2);
      produto.AdicionarEstoque(qtd2);

      System.Console.WriteLine("insira a quantidade que quer vender: ");
      bool valid4 = int.TryParse(Console.ReadLine(), out int qtd3);
      produto.VenderProduto(qtd3);

      produto.ExibirInfo();
    }
  }
}