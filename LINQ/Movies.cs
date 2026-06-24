namespace LinqExercise
{
  public class Movie
  {
    public string Name { get ; set; }
    public string Director { get ; set; }
    public string ReleaseDate { get ; set; }
    public string Genre { get ; set; }

    public Movie(string name, string director, string releaseDate, string genre)
    {
      Name = name;
      Director = director;
      ReleaseDate = releaseDate;
      Genre = genre;
    }
  }
}