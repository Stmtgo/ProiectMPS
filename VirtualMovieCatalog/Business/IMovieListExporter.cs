using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualMovieCatalog.Business
{
    interface IMovieListExporter
    {
        void ExportListOfMovies(List<Movie> listOfMovies);
    }
}
