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
            Func<String, String> Trim = s => s.Trim();

            List<string> genreList = genre.Split(',').Select(Trim).ToList();
            List<string> directorsList = directors.Split(',').Select(Trim).ToList();
            List<string> movieCdDvdTextBoxList = movieCdDvdTextBox.Split(',').Select(Trim).ToList();
            List<string> subtitlesList = subtitles.Split(',').Select(Trim).ToList();
            List<string> actorsList = actors.Split(',').Select(Trim).ToList();

            Movie auxMovie = new Movie(name, genreList, directorsList, actorsList, subtitlesList, movieCdDvdTextBoxList, description, Convert.ToInt32(releaseYear), Convert.ToInt32(duration));
            dataTransferManager.insertMovie(auxMovie);
        }

        public void DeleteMovie()
        {
            if (movieCatalog.CurrentlySelectedMovie != null)
            {
                DialogResult dialogResult = MessageBox.Show("Chiar doriti sa stergeti filmul " + movieCatalog.CurrentlySelectedMovie.Name, "Stergere film", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dataTransferManager.DeleteMovie(movieCatalog.CurrentlySelectedMovie);
                }
            }
        }

        public void EditMovie(Movie movie)
        {
            if (movieCatalog.CurrentlySelectedMovie != null)
            {
                DialogResult dialogResult = MessageBox.Show("Chiar doriti sa modificati datele filmului " + movieCatalog.CurrentlySelectedMovie.Name, "Editare film", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dataTransferManager.EditMovie(movie);
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
