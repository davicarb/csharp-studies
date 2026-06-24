using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace LinqExercise
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var movies = new List<Movie>();
      var movie1 = new Movie("Titanic", "James Cameron", "1997", "Romance");
      var movie2 = new Movie("The Dark Knight", "Christopher Nolan", "2008", "Action");
      var movie3 = new Movie("Interstellar", "Christopher Nolan", "2014", "Sci-Fi");
      var movie4 = new Movie("The Godfather", "Francis Ford Coppola", "1972", "Crime");
      var movie5 = new Movie("Inception", "Christopher Nolan", "2010", "Thriller");

      movies.Add(movie1);
      movies.Add(movie2);
      movies.Add(movie3);
      movies.Add(movie4);
      movies.Add(movie5);

      // linq part

      Console.WriteLine("Movies released in 1997");
      var movies1997 = movies.Where(m => m.ReleaseDate == "1997")
      .ToList();

      foreach (var m in movies1997)
      {
        System.Console.WriteLine(m.Name);
      }

      Console.WriteLine("Movies of the Romance genre");
      // Implementation

      Console.WriteLine("Return movies in alphabetical order.");
      // Implementation

      Console.WriteLine("Movies directed by Christopher Nolan");
      // Implementation

      Console.WriteLine("Last two movies registered in alphabetical order.");
      // Implementation
    }
  }
}