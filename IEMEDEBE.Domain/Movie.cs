using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.Domain
{
    public class Movie
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Director Director { get; set; }
        public List<Genre> Genres { get; set; }
        //public List<MovieRating> UsersRating { get; set; }
        public int TotalRates { get; set; }
        public int Rates { get; set; }
        private static int MovieId = 0;
        public Double AverageRate;

        public Movie()
        {
            Name = "";
            Id = MovieId++;
            ReleaseDate = new DateTime();
            Director = new Director();
            Genres = new List<Genre>();
            TotalRates = 0;
            Rates = 0;
        }
        public double getAverage()
        {
            return this.AverageRate;
        }

        public void AddGenre(Genre genre)
        {
            if (!ExistsGenre(genre))
            {
                Genres.Add(genre);
            }
            else
            {
                throw new ArgumentException("Already exist the genre in the movie. It is not possible to add.");
            }
        }
        public void setAverage()
        {
            if (TotalRates > 0)
            {
                AverageRate = (Rates / TotalRates);
            }
            else
            {
                AverageRate = 0;
            }
        }

        private bool ExistsGenre(Genre genre)
        {
            return Genres.Contains(genre);
        }


        public override bool Equals(object obj)
        {
            return obj is Movie movie &&
                   this.Name.Equals(movie.Name);
        }


        public override string ToString()
        {
            return $"Id: {Id}  - Name:  {Name} - AverageRate: {AverageRate} - TotalRates: {TotalRates} - Director: {Director.Name} Date: {ReleaseDate}";
        }
    }
}
