namespace AnimaisHeranca
{
  public class Animal
  {
    public string Nome { get; set; }
    public string Som { get; set; }

    public Animal(string nome, string som)
    {
      Nome = nome;
      Som = som;
    }
    public virtual void FazerSom() { }
    // virtual signfiica:
    // a classe filha pode alterar este método.
  }

  public class Cachorro : Animal
  {
    public Cachorro(string nome) : base(nome, "auau") { }
    public override void FazerSom()
    // aqui, a classe filha altera como o método FazerSom() funciona
    // para o cachorro em específico.
    {
      Console.WriteLine(Som);
    }

  }
  public class Gato : Animal
  {
    public Gato(string nome) : base (nome, "miau, ronron!") { }
    public override void FazerSom()
    // o mesmo para o gato!
    {
      Console.WriteLine(Som);
    }

  }

  public class Passaro : Animal
  {
    public Passaro(string nome) : base (nome, "cantando uma melodia bonita de manhã ao nascer do sol...") { }
    public override void FazerSom()
     // o mesmo para o pássaro...
    {
      System.Console.WriteLine(Som);
    }
  }

  public class Leao : Animal
  {
    public Leao(string nome) : base (nome, "rugido nas densas florestas...") { }

    public override void FazerSom()
    // e para o leão!
    {
      System.Console.WriteLine(Som);
    }
  }
}