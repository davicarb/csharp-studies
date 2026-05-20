using System.Runtime;
using System.Xml.Serialization;

namespace AnimaisHeranca
{
  class Program
  {
    static void Main (string[] args)
    {
      System.Console.WriteLine("\n");
      var animals = new List<Animal>();
      var gato = new Gato("nina");
      var cachorro = new Cachorro("bob");
      var leao = new Leao("roberto");
      var passaro = new Passaro("joao");
      // instanciamos todos os objetos que vamos usar para 
      // testar a herança e polimorfismo...

      animals.Add(gato);
      animals.Add(cachorro);
      animals.Add(leao);
      animals.Add(passaro);
      // adicionamos eles na List<Animal> para percorrermos
      // usando um foreach...

      foreach (var animal in animals)
      {
        System.Console.WriteLine($"{animal.Nome}");
        animal.FazerSom();
        System.Console.WriteLine("\n");
      }
      // cada objeto faz seu som de sua respectiva forma,
      // usando a herança e o polimorfismo!
    }
  }
}