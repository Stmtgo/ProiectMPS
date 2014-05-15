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
            var dataManager = new DataTransferManager("asd", "asd", "asd", "asd");

            var directors = new List<String>();
            directors.Add( "Director2");
            directors.Add( "SomeGuy");
            directors.Add("SomeNewGuy");
            directors.Add("SomeNewer_Guy");

            var movie = new Movie("NewFilm3", new List<String>(), directors, new List<String>(), new List<String>(), new List<String>(), "Some description", 1999);


            dataManager.insertMovie( movie);

            var mov = dataManager.getMovies();


            Form1 mainForm = new Form1();
            MainController mainController = new MainController(mainForm);
        }
    }
}
