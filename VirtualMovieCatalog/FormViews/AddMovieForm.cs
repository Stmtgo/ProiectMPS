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

        private void AddMovieForm_Load(object sender, EventArgs e)
        {

        }

       
    }
}
