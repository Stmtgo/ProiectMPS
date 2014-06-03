using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VirtualMovieCatalog.Business;
using System.Windows.Forms;

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
            var moviesList = dataTransferManager.getAllMovies();
            movieCatalog.ListOfMovies = moviesList;
            movieCatalog.CurrentlySelectedMovie = null;
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

        public void AddMovie(string name, string genre, string directors, string movieCdDvdTextBox,string releaseYear, string rating,
                             string duration, string subtitles, string actors, string trailerUrl, string description)
        {
            List<string> genreList = new List<string>(genre.Split(','));
            List<string> directorsList = new List<string>(directors.Split(','));
            List<string> movieCdDvdTextBoxList = new List<string>(movieCdDvdTextBox.Split(','));
            List<string> subtitlesList = new List<string>(subtitles.Split(','));
            List<string> actorsList = new List<string>(actors.Split(','));

            Movie auxMovie = new Movie(name, genreList, directorsList, actorsList, subtitlesList, movieCdDvdTextBoxList, description, Convert.ToInt32(releaseYear), duration);
            dataTransferManager.insertMovie(auxMovie);
        }

        public void DeleteMovie()
        {
            if (movieCatalog.CurrentlySelectedMovie != null)
            {
                DialogResult dialogResult = MessageBox.Show("Do you really want to delete the movie " + movieCatalog.CurrentlySelectedMovie.Name, "Delete movie", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //dataTransferManager.DeleteMovie(movieCatalog.CurrentlySelectedMovie);
                }
            }
        }

        //Private Methods==========================================================================
        private void SetMovieList()
        {
           // movieCatalog.SetMoviesList(dataTransferManager.GetMovies());
        }








        
    }
}
