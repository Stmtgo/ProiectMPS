﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VirtualMovieCatalog.Controllers;

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

            Form1 mainForm = new Form1();
            MainController mainController = new MainController(mainForm);
        }
    }
}
