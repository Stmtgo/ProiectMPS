using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VirtualMovieCatalog.Business;
using VirtualMovieCatalog.Controllers;
using VirtualMovieCatalog.FormViews;

namespace VirtualMovieCatalog
{
    public partial class Form1 : Form
    {
        //Data Members=============================================================================
        MainController mainController;

        //Constructor(s)===========================================================================
        public Form1()
        {
            mainController = new MainController();
            InitializeComponent();
        }

        //Public Methods===========================================================================
        public void UpdateListOfMovies(List<Movie> listOfMovies)
        {
            var contor = 1;

            foreach (var movie in listOfMovies)
            {
                ListViewItem auxItem = new ListViewItem(contor.ToString());
                auxItem.SubItems.Add(movie.Name);
                moviesListView.Items.Add(auxItem);
                contor++;
            }
        }

        public void SetMainController(MainController mainController)
        {
            this.mainController = mainController;
        }
        public void DisplayMovieInfo(Movie movie)
        {
            movieNameTextBox.Text = movie.Name;
            movieReleaseYearTextBox.Text = movie.Year.ToString();
            movieDescriptionTextBox.Text += movie.Description;
             

            foreach (var item in movie.Directors)
            {
                movieRegizorTextbox.Text += item + ", ";
            }
            movieRegizorTextbox.Text.Remove(movieRegizorTextbox.Text.Length - 2);

            foreach (var item in movie.Actors)
            {
                movieActorsTextBox.Text += item + ", ";
            }
            movieActorsTextBox.Text.Remove(movieRegizorTextbox.Text.Length - 2);

            foreach (var item in movie.Genres)
            {
                movieGenreTextBox.Text += item + ", ";
            }
            movieGenreTextBox.Text.Remove(movieRegizorTextbox.Text.Length - 2);

            foreach (var item in movie.Subtitles)
            {
                movieSubtitleTextBox.Text += item + ", ";
            }
            movieSubtitleTextBox.Text.Remove(movieRegizorTextbox.Text.Length - 2);

            foreach (var item in movie.Discs)
            {
                movieCdDvdTextBox.Text += item + ", ";
            }
            movieCdDvdTextBox.Text.Remove(movieRegizorTextbox.Text.Length - 2);
        }

        public void ClearAllInfoShowingTextboxes()
        {
            movieNameTextBox.Text = "";
            movieRegizorTextbox.Text = "";
            movieGenreTextBox.Text = "";
            movieReleaseYearTextBox.Text = "";
            movieRatingTextBox.Text = "";
            movieDurationTextBox.Text = "";
            movieCdDvdTextBox.Text = "";
            movieActorsTextBox.Text = "";
        }

        //Private Methods==========================================================================
        private void moviesListView_Click(object sender, EventArgs e)
        {
            if (moviesListView.SelectedItems.Count > 0)
            {
                int index = moviesListView.SelectedIndices[0];
                mainController.SetCurrentlySelectedMovie(index);
            }
        }

        private void addMovieButton_Click(object sender, EventArgs e)
        {
            AddMovieForm addMovieForm = new AddMovieForm();
            addMovieForm.SetMainController(mainController);
            addMovieForm.ShowDialog();
        }

        
    }
}
