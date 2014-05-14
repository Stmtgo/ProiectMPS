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

            var movie = new Movie("Matrix222", new List<String>(), directors, new List<String>(), new List<String>(), new List<int>(), "Some description", 1999);


            dataManager.insertMovie( movie);


            Form1 mainForm = new Form1();
            MainController mainController = new MainController(mainForm);
        }
    }
}
