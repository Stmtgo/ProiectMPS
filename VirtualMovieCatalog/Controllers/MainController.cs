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
            InitializeForm();
        }

        //Public Methods===========================================================================
        public void SetMainForm(Form1 mainForm)
        {
            this.mainForm = mainForm;
        }

        public void SetCurrentlySelectedMovie(int index)
        {
            movieCatalogController.SetCurrentlySelectedMovie(index);
            mainForm.DisplayMovieInfo(movieCatalogController.GetCurrentlySelectedMovie());
        }




        //Private Methods==========================================================================
        private void InitializeData()
        {
            movieCatalogController.LoadDataFromDb();
        }

        private void InitializeForm()
        {   
            //mainForm.UpdateListOfMovies(movieCatalogController.GetListOfMovies());
        }


        
    }
}
