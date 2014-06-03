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
            string a = "asdasdas";
            a +=", ";
            a = a.Remove(a.Length - 2)

            Application.EnableVisualStyles();
            
            Form1 mainForm = new Form1();
            MainController mainController = new MainController();

            mainForm.SetMainController(mainController);
            mainController.SetMainForm(mainForm);

            Application.Run(mainForm);
        }
    }
}
