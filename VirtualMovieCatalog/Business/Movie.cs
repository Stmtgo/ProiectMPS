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
        int duration;


        //Constructor(s)===========================================================================
        public Movie(string name, List<string> genres, List<string> directors, List<string> actors, List<string> subtitles, List<String> discs,string description, int year, int duration)
        {
            this.Name = name;
            this.Genres = genres;
            this.Directors = directors;
            this.Actors = actors;
            this.Subtitles = subtitles;
            this.Discs = discs;
            this.Description = description;
            this.Year = year;
            this.duration = duration;
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

        public List<String> Discs
        {
            get { return discs; }
            set { discs = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        //Public Methods===========================================================================


        //Private Methods==========================================================================



    }
}
