using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualMovieCatalog.Business;

namespace VirtualMovieCatalog.Controllers
{
    public class MovieCatalogController
    {
        //Data Members=============================================================================
        private MovieCatalog movieCatalog;
        private DataTransferManager dataTransferManager;
        private DatabaseConfig dbConfig;

        //Constructor(s)===========================================================================
        public MovieCatalogController()
        {
            movieCatalog = new MovieCatalog();
            dbConfig = new DatabaseConfig();
            dataTransferManager = new DataTransferManager();

        }

        //Public Methods===========================================================================
        public void LoadDataFromDb()
        {
            //var moviesList =  dataTransferManager.getMovies();
            //movieCatalog.ListOfMovies = moviesList;
        }

        public List<Movie> GetListOfMovies()
        {
            return movieCatalog.ListOfMovies;
        }

        public void SetCurrentlySelectedMovie(int index)
        {
            movieCatalog.SetCurrentlySelectedMovie(index);
        }

        public Movie GetCurrentlySelectedMovie()
        {
            return movieCatalog.CurrentlySelectedMovie;
        }
        //Private Methods==========================================================================
        private void SetMovieList()
        {
           // movieCatalog.SetMoviesList(dataTransferManager.GetMovies());
        }




        
    }
}
