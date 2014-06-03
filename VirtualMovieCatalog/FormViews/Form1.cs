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
            ClearMovieListBox();
            ClearAllInfoShowingTextboxes();
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
            if (movieRegizorTextbox.Text.Length > 2)
                movieRegizorTextbox.Text = movieRegizorTextbox.Text.Remove(movieRegizorTextbox.Text.Length - 2);

            foreach (var item in movie.Actors)
            {
                movieActorsTextBox.Text += item + ", ";
            }
            if (movieActorsTextBox.Text.Length > 2)
                movieActorsTextBox.Text = movieActorsTextBox.Text.Remove(movieActorsTextBox.Text.Length - 2);

            foreach (var item in movie.Genres)
            {
                movieGenreTextBox.Text += item + ", ";
            }
            if (movieGenreTextBox.Text.Length > 2)
                movieGenreTextBox.Text = movieGenreTextBox.Text.Remove(movieGenreTextBox.Text.Length - 2);

            foreach (var item in movie.Subtitles)
            {
                movieSubtitleTextBox.Text += item + ", ";
            }
            if (movieSubtitleTextBox.Text.Length > 2)
                movieSubtitleTextBox.Text = movieSubtitleTextBox.Text.Remove(movieSubtitleTextBox.Text.Length - 2);

            foreach (var item in movie.Discs)
            {
                movieCdDvdTextBox.Text += item + ", ";
            }
            if (movieCdDvdTextBox.Text.Length > 2)
                movieCdDvdTextBox.Text = movieCdDvdTextBox.Text.Remove(movieCdDvdTextBox.Text.Length - 2);
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
            movieDescriptionTextBox.Text = "";
        }

        //Private Methods==========================================================================
        private void moviesListView_Click(object sender, EventArgs e)
        {           
            if (moviesListView.SelectedItems.Count > 0)
            {
                ClearAllInfoShowingTextboxes();
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

        private void ClearMovieListBox()
        {
            moviesListView.Items.Clear();
        }
        
    }
}
