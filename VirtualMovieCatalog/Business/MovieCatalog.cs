using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualMovieCatalog.Business
{
    public class MovieCatalog
    {
        //Data Members=============================================================================
        private List<Movie> listOfMovies;
        private MovieFilter movieFilter;
        private IMovieListExporter movieListExporter;
        private MovieDataImporter movieDataImporter;

        //Constructor(s)===========================================================================
        public MovieCatalog()
        {
            listOfMovies = new List<Movie>();
        }

        //Properties===============================================================================
        

        //Public Methods===========================================================================
        public void SetMoviesList(List<Movie> listOfMovies)
        {
            this.listOfMovies = listOfMovies;
        }

        public void AddMovie(string name, List<string> genres, List<string> directors, List<string> actors, List<string> subtitles, List<String> disks, string description, int year)
        {
            var createdMovie = CreateMovie(name, genres, directors, actors, subtitles, disks, description, year);
            //dataTransferManager.AddMovie(createdMovie);
        }

        

        public void DeleteMovie() 
        {
 
        }

        public void SaveMoviesList()
        { 
        }

        public List<Movie> FilterListOfMovies(string criteria)
        {
            return null;
        }

        //Private Methods==========================================================================
        private Movie CreateMovie(string name, List<string> genres, List<string> directors, List<string> actors, List<string> subtitles, List<String> disks, string description, int year)
        {
            return new Movie(name, genres, directors, actors, subtitles, disks, description, year);
        }
    }
}
