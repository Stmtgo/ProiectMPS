using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VirtualMovieCatalog.Controllers;

namespace VirtualMovieCatalog.FormViews
{  
    public partial class AddMovieForm : Form
    {
        //Data Members=============================================================================
        MainController mainController;

        //Constructor(s)===========================================================================
        public AddMovieForm()
        {
            InitializeComponent();
        }

        //Public Methods===========================================================================
        public void SetMainController(MainController mainController)
        {
            this.mainController = mainController;
        }

        //Private Methods==========================================================================
        private void addMovieButton_Click(object sender, EventArgs e)
        {
            mainController.AddMovie(movieNameTextBox.Text,
                                    movieGenreTextBox.Text,
                                    movieRegizorTextbox.Text,
                                    movieCdDvdTextBox.Text,
                                    movieReleaseYearTextBox.Text,
                                    movieRatingTextBox.Text,
                                    movieDurationTextBox.Text,
                                    movieSubtitleTextBox.Text,
                                    movieActorsTextBox.Text,
                                    movieTrailerUrlTextBox.Text,
                                    movieDescriptionTextBox.Text);
            Close();
        }


       
    }
}
