using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VirtualMovieCatalog.Controllers;
using VirtualMovieCatalog.Business;

namespace VirtualMovieCatalog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var dataManager = new DataTransferManager();

            var directors = new List<String>();
            directors.Add( "Director2");
            directors.Add( "SomeGuy");
            directors.Add("SomeNewGuy");
            directors.Add("SomeNewer_Guy");

            var discs = new List<String>();
            discs.Add( "Pe birou");

            var movie = new Movie("NewFilm6", new List<String>(), directors, new List<String>(), new List<String>(), discs, "Some description", 1992, 2);

            dataManager.getMovies("director", "SomeNewer_Guy");
            List<Movie> movies = dataManager.getMovies("", "");

            Application.EnableVisualStyles();
            Form1 mainForm = new Form1();
            MainController mainController = new MainController(mainForm);
        }
    }
}
