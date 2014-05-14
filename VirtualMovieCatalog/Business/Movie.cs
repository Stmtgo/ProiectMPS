using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualMovieCatalog.Business
{
    public class Movie
    {
        //Data Members=============================================================================
        string name;
        List<string> directors;
        List<string> actors;
        List<string> genres;
        List<string> subtitles;
        List<string> discs;
        string description;
        int year;
        int nrDiscs;


        //Constructor(s)===========================================================================
        public Movie(string name, List<string> genres, List<string> directors, List<string> actors, List<string> subtitles, List<String> discs,string description, int year)
        {
            this.name = name;
            this.genres = genres;
            this.directors = directors;
            this.actors = actors;
            this.subtitles = subtitles;
            this.discs = discs;
            this.description = description;
            this.year = year;
        }

        //Properties===============================================================================
        public string Name
        { 
            get { return name; }
            set { name = value; }
        }

        public List<string> Directors
        {
            get { return directors; }
            set { directors = value; }
        }

        public List<string> Actors
        {
            get { return actors; }
            set { actors = value; }
        }

        public List<string> Genres
        {
            get { return genres; }
            set { genres = value; }
        }

        public List<string> Subtitles
        {
            get { return subtitles; }
            set { subtitles = value; }
        }

        public List<String> Disks
        {
            get { return discs; }
            set { discs = value; }
        }

        public string Descripsion
        {
            get { return description; }
            set { description = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int NrDiscs
        {
            get { return nrDiscs; }
            set { nrDiscs = value; }
        }

        //Public Methods===========================================================================


        //Private Methods==========================================================================



    }
}
