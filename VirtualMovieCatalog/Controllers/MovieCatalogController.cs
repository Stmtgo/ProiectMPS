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


        //Private Methods==========================================================================
        private void SetMovieList()
        {
           // movieCatalog.SetMoviesList(dataTransferManager.GetMovies());
        }

    }
}
