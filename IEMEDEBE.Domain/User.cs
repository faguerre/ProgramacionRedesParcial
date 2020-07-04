using System;
using System.Collections.Generic;

namespace IEMEDEBE.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
        public List<Movie> FavouriteMovies { get; set; }

        public User()
        {
            FavouriteMovies = new List<Movie>();
        }

        public void AddFavouriteMovie(Movie movie)
        {
            FavouriteMovies.Add(movie);
        }
        public void DeleteFavouriteMovie(Movie movie)
        {
            FavouriteMovies.Remove(movie);
        }
        public bool IsFavouriteMovie(Movie movie)
        {
            return FavouriteMovies.Contains(movie);
        }

        public override string ToString()
        {
            return $"NickName: {NickName}  - FullName:  {FullName} - Birthday: {Birthday}- Mail: {Mail}";
        }
    }
}
