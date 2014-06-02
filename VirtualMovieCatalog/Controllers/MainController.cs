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
        public MainController(Form1 mainForm)
        {
            this.mainForm = mainForm;
            movieCatalogController = new MovieCatalogController();

            InitializeForm();
        }

        //Public Methods===========================================================================

        //Private Methods==========================================================================
        private void InitializeForm()
        {
            Application.Run(mainForm);
        
        }

    }
}
