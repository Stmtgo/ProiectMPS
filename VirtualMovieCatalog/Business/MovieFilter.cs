using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualMovieCatalog.Business
{
    class MovieFilter
    {
        //Public Methods===========================================================================
        public List<Movie> GetMovieByName(List<Movie> listOfMovies, string name)
        {
            return listOfMovies.Where(item => item.Name == name).ToList();
        }

        public List<Movie> GetMovieByGenre(List<Movie> listOfMovies, string genre)
        {
            return listOfMovies.Where(item => item.Genres.Contains(genre)).ToList();
        }

        public List<Movie> GetMovieByRegizor(List<Movie> listOfMovies, string regizor)
        {
            return listOfMovies.Where(item => item.Directors.Contains(regizor)).ToList();
        }

        public List<Movie> GetMovieByActors(List<Movie> listOfMovies, string actor)
        {
            return listOfMovies.Where(item => item.Actors.Contains(actor)).ToList();
        }

        public List<Movie> GetMovieByYear(List<Movie> listOfMovies, int year)
        {
            return listOfMovies.Where(item => item.Year == year).ToList();
        }
    }
}
