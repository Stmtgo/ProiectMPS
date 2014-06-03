using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualMovieCatalog.Business
{
    interface IMovieDataImporter
    {
        Movie GetMovieByName(string movieName);
    }
}
