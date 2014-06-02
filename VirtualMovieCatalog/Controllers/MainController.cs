using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VirtualMovieCatalog.Controllers
{
    public class MainController
    {
        //Data Members=============================================================================
        Form1 mainForm;
        MovieCatalogController movieCatalogController;

        //Constructor(s)===========================================================================
        public MainController()
        {
            this.mainForm = mainForm;
            movieCatalogController = new MovieCatalogController();
            InitializeData();
            
        }

        //Public Methods===========================================================================
        public void SetMainForm(Form1 mainForm)
        {
            this.mainForm = mainForm;
            InitializeForm();
        }

        public void SetCurrentlySelectedMovie(int index)
        {
            movieCatalogController.SetCurrentlySelectedMovie(index);
            mainForm.DisplayMovieInfo(movieCatalogController.GetCurrentlySelectedMovie());
        }

        public void AddMovie(string name, string genre, string directors, string movieCdDvdTextBox, string releaseYear, string rating,
                             string duration, string subtitles, string actors, string trailerUrl, string description)
        {
            movieCatalogController.AddMovie(name, genre, directors, movieCdDvdTextBox, releaseYear, rating,
                                            duration,subtitles,actors,trailerUrl,description);
            InitializeData();
            InitializeForm();
        }
        //Private Methods==========================================================================
        private void InitializeData()
        {
            movieCatalogController.LoadDataFromDb();
        }

        private void InitializeForm()
        {   
            mainForm.UpdateListOfMovies(movieCatalogController.GetListOfMovies());
        }




        
    }
}
