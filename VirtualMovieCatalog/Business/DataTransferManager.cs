﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;

namespace VirtualMovieCatalog.Business
{
    class DataTransferManager
    {
        //Data Members=============================================================================
        private const String connectionString = "Data Source=(LocalDb)\\v11.0;AttachDbFilename=|DataDirectory|\\movies.mdf;Initial Catalog=movies;Integrated Security=True";

        //Constructor(s)===========================================================================
        public DataTransferManager()
        { }

        //Public Methods===========================================================================

        public List<Movie> getAllMovies()
        {
            List<int> movieIds = GetMovieIds("", "");
            return GetMoviesByIds(movieIds);
        }

        // filter can take the following values:
        // name, year, nrdiscs, genre, actor, director, disc, ""
        public List<Movie> getMovies(String filter, String value)
        {
            List<int> movieIds = GetMovieIds(filter, value);
            return GetMoviesByIds(movieIds);
        }

        public bool insertMovie(Movie movie)
        {
            var status = true;

            using (var transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    int insertedId = AddMovie(movie.Name, movie.Description, movie.Year, movie.Duration);

                    List<int> directorIds = Add("directors", movie.Directors);
                    List<int> genreIds = Add("genres", movie.Genres);
                    List<int> subtitleIds = Add("subtitles", movie.Subtitles);
                    List<int> actorIds = Add("actors", movie.Actors);
                    List<int> discIds = Add("discs", movie.Discs);

                    LinkMovieAnd("director", insertedId, directorIds);
                    LinkMovieAnd("genre", insertedId, genreIds);
                    LinkMovieAnd("subtitle", insertedId, subtitleIds);
                    LinkMovieAnd("actor", insertedId, actorIds);
                    LinkMovieAnd("disc", insertedId, discIds);

                    // commits the changes to the database
                    transaction.Complete();

                }
                catch (Exception e)
                {
                    status = false;
                }
            }

            return status;
        }

        public void DeleteMovie(Movie movie)
        {
            var id = getMovieId(movie);

            if (id != 0)
            {
                RemoveMovie(id);
            }
        }

        public void EditMovie(Movie movie)
        {
            var id = getMovieId(movie);

            if (id != 0)
            {
                UpdateMovie(id, movie);
            }
        }

        //Private Methods==========================================================================

        private int getMovieId(Movie movie)
        {
            int movieID = 0;

            String selectComand = "SELECT id FROM movies WHERE name = @name AND year = @year;";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand select = new SqlCommand(selectComand, con))
                {
                    select.Parameters.Add("@name", System.Data.SqlDbType.NVarChar);
                    select.Parameters["@name"].Value = movie.Name;
                    select.Parameters.Add("@year", System.Data.SqlDbType.Int);
                    select.Parameters["@year"].Value = movie.Year;

                    movieID = Convert.ToInt32(select.ExecuteScalar());
                }
            }

            return movieID;
        }

        private void RemoveMovie(int id)
        {
            // No prepare for SQL INJECTION necessary here (data is sanitized)
            String removeComand = "DELETE FROM movies WHERE id = " + id;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand remove = new SqlCommand(removeComand, con))
                {
                    remove.ExecuteNonQuery();
                }
            }
        }

        private bool UpdateMovie(int id, Movie movie)
        {

            var status = true;

            using (var transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    // get old info
                    var oldDirectors = Get("director", id);
                    var oldGenres = Get("genre", id);
                    var oldSubtitles = Get("subtitle", id);
                    var oldActors = Get("actor", id);
                    var oldDiscs = Get("disc", id);

                    // add new info
                    UpdateBasicComponents(id, movie.Name, movie.Description, movie.Year, movie.Duration);

                    List<int> directorIds = Add("directors", movie.Directors);
                    List<int> genreIds = Add("genres", movie.Genres);
                    List<int> subtitleIds = Add("subtitles", movie.Subtitles);
                    List<int> actorIds = Add("actors", movie.Actors);
                    List<int> discIds = Add("discs", movie.Discs);

                    LinkMovieAnd("director", id, directorIds);
                    LinkMovieAnd("genre", id, genreIds);
                    LinkMovieAnd("subtitle", id, subtitleIds);
                    LinkMovieAnd("actor", id, actorIds);
                    LinkMovieAnd("disc", id, discIds);

                    // remove extra info
                    var extraDirectors = oldDirectors.Except(movie.Directors, StringComparer.OrdinalIgnoreCase).ToList();
                    var extraGenres = oldGenres.Except(movie.Genres, StringComparer.OrdinalIgnoreCase).ToList();
                    var extraSubtitles = oldSubtitles.Except(movie.Subtitles, StringComparer.OrdinalIgnoreCase).ToList();
                    var extraActors = oldActors.Except(movie.Actors, StringComparer.OrdinalIgnoreCase).ToList();
                    var extraDiscs = oldDiscs.Except(movie.Discs, StringComparer.OrdinalIgnoreCase).ToList();

                    DeleteExtra("director", extraDirectors, id);
                    DeleteExtra("genre", extraGenres, id);
                    DeleteExtra("subtitle", extraSubtitles, id);
                    DeleteExtra("actor", extraActors, id);
                    DeleteExtra("disc", extraDiscs, id);

                    // commits the changes to the database
                    transaction.Complete();

                }
                catch (Exception e)
                {
                    status = false;
                }
            }

            return status;
        }

        private void UpdateBasicComponents(int id, string name, string description, int year, int duration)
        {
            String updateComand = "UPDATE movies SET name = @name, description = @description, year = @year, nrDiscs = @duration WHERE id = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand update = new SqlCommand(updateComand, con))
                {
                    update.Parameters.Add("@name", System.Data.SqlDbType.NVarChar);
                    update.Parameters["@name"].Value = name;
                    update.Parameters.Add("@description", System.Data.SqlDbType.NVarChar);
                    update.Parameters["@description"].Value = description;
                    update.Parameters.Add("@year", System.Data.SqlDbType.Int);
                    update.Parameters["@year"].Value = year;
                    update.Parameters.Add("@duration", System.Data.SqlDbType.NVarChar);
                    update.Parameters["@duration"].Value = duration;
                    update.Parameters.Add("@id", System.Data.SqlDbType.Int);
                    update.Parameters["@id"].Value = id;

                    update.ExecuteNonQuery();
                }
            }
        }

        private List<string> Get(string table, int id)
        {
            String selectComand = "SELECT name from " + table + "s T" +
                                  " INNER JOIN movies_" + table + "s MT ON" +
                                  " MT.movieid = " + id +
                                  " AND MT." + table + "id = T.id;";

            List<String> names = new List<String>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand select = new SqlCommand(selectComand, con))
                {
                    var results = select.ExecuteReader();
                    while (results.Read())
                    {
                        names.Add(results["name"].ToString());
                    }
                }
            }

            return names;
        }

        private void DeleteExtra(string table, List<string> extraNames, int id)
        {
            string deleteComand = "DELETE MT FROM movies_" + table + "s MT" +
                                  " INNER JOIN " + table + "s T" +
                                  " ON MT.movieid = " + id +
                                  " AND MT." + table + "id = T.id" +
                                  " AND T.name = @extraName";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand delete = new SqlCommand(deleteComand, con))
                {
                    delete.Parameters.Add("@extraName", System.Data.SqlDbType.NVarChar);

                    foreach (var extraName in extraNames)
                    {
                        delete.Parameters["@extraName"].Value = extraName;
                        delete.ExecuteNonQuery();
                    }
                }
            }
        }

        private List<int> GetMovieIds(String filter, String value)
        {
            List<int> movieIds = null;

            switch (filter)
            {
                case "name":
                case "year":
                case "nrDiscs":
                    movieIds = SimpleQuery(filter, value);
                    break;
                case "genre":
                case "actor":
                case "director":
                case "disc":
                    movieIds = ComplexQuery(filter, value);
                    break;
                default:
                    movieIds = AllQuery();
                    break;
            }

            return movieIds;
        }

        private List<int> AllQuery()
        {
            String selectComand = "SELECT id FROM movies;";

            List<int> movieIds = new List<int>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand select = new SqlCommand(selectComand, con))
                {
                    SqlDataReader result = select.ExecuteReader();

                    while (result.Read())
                    {
                        movieIds.Add(Convert.ToInt32(result["id"]));
                    }
                }
            }

            return movieIds;
        }

        /**
         * Selects movie ids
         */
        private List<int> SimpleQuery(String property, String value)
        {
            String selectComand = "SELECT id FROM movies WHERE " + property + " = @value;";

            List<int> movieIds = new List<int>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand select = new SqlCommand(selectComand, con))
                {
                    select.Parameters.Add("@value", System.Data.SqlDbType.NVarChar);
                    select.Parameters["@value"].Value = value;

                    SqlDataReader result = select.ExecuteReader();

                    while (result.Read())
                    {
                        movieIds.Add(Convert.ToInt32(result["id"]));
                    }
                }
            }

            return movieIds;
        }

        /**
         * Selects movie ids by joining multiple tables
         */
        private List<int> ComplexQuery(String property, String value)
        {
            String selectComand = "SELECT M.movieid id " +
                            "FROM movies_" + property + "s AS M " +
                            "INNER JOIN " + property + "s AS D ON " +
                            "D.id = M." + property + "id AND D.name = @value;";

            List<int> movieIds = new List<int>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand select = new SqlCommand(selectComand, con))
                {
                    select.Parameters.Add("@value", System.Data.SqlDbType.NVarChar);
                    select.Parameters["@value"].Value = value;

                    SqlDataReader result = select.ExecuteReader();

                    while (result.Read())
                    {
                        movieIds.Add(Convert.ToInt32(result["id"]));
                    }
                }
            }

            return movieIds;
        }

        private List<Movie> GetMoviesByIds(List<int> movieIds)
        {
            List<Movie> movies = new List<Movie>();

            foreach (int id in movieIds)
            {
                Dictionary<String, String> movieComponents = GetMovieBasicComponents(id);

                List<string> directors = GetById("director", id);
                List<string> actors = GetById("actor", id);
                List<string> genres = GetById("genre", id);
                List<string> subtitles = GetById("subtitle", id);
                List<string> discs = GetById("disc", id);

                Movie movie = new Movie(movieComponents["name"], genres, directors, actors, subtitles, discs, movieComponents["description"], Convert.ToInt32(movieComponents["year"]), Convert.ToInt32(movieComponents["nrDiscs"]));
                movies.Add(movie);
            }

            return movies;
        }

        private Dictionary<String, String> GetMovieBasicComponents(int id)
        {
            var basicComponents = new Dictionary<String, String>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand select = new SqlCommand("SELECT name, description, year, nrDiscs FROM movies WHERE id = @id", con))
                {
                    select.Parameters.Add("@id", System.Data.SqlDbType.Int);
                    select.Parameters["@id"].Value = id;

                    SqlDataReader result = select.ExecuteReader();

                    if (result.Read())
                    {
                        basicComponents.Add("name", result["name"].ToString());
                        basicComponents.Add("description", result["description"].ToString());
                        basicComponents.Add("year", result["year"].ToString());
                        basicComponents.Add("nrDiscs", result["nrDiscs"].ToString());
                    }
                }
            }

            return basicComponents;
        }

        private List<String> GetById(String table, int id)
        {
            // no need to prepare for SQL INJECTION here (data is sanitized)
            String selectComand = "SELECT D.name name FROM " + table + "s D " +
                                  "INNER JOIN movies_" + table + "s M ON " +
                                  "D.id = M." + table + "id AND M.movieid = " + id;

            List<String> result = new List<String>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand select = new SqlCommand(selectComand, con))
                {
                    var queryResult = select.ExecuteReader();

                    while (queryResult.Read())
                    {
                        result.Add(queryResult["name"].ToString());
                    }
                }
            }

            return result;
        }

        /**
         * Inserts a movie into the database and returns the resulting id
         */
        private int AddMovie(String name, String description, int year, int duration)
        {

            int id;

            String insertCommand = "INSERT INTO movies( name, description, year, nrDiscs) " +
                                   "VALUES ( @name, @description, @year, @nrDiscs); " +
                                   "SELECT SCOPE_IDENTITY();";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand insert = new SqlCommand(insertCommand, con))
                {
                    insert.Parameters.AddWithValue("@name", name);
                    insert.Parameters.AddWithValue("@description", description);
                    insert.Parameters.AddWithValue("@year", year);
                    insert.Parameters.AddWithValue("@nrDiscs", duration);

                    id = Convert.ToInt32(insert.ExecuteScalar());
                }
            }

            return id;
        }

        /**
         * Adds all the @entities to the @table and returns the resulting ids
         */
        private List<int> Add(String table, List<String> entities)
        {

            String insertCommand = "IF NOT EXISTS(SELECT TOP 1 1 FROM " + table + " WHERE name = @name) " +
                "BEGIN " +
                    "INSERT INTO " + table + " (name) " +
                    "VALUES (@name); " +
                    "SET @id = SCOPE_IDENTITY(); " +
                "END " +
                "ELSE " +
                "BEGIN " +
                    "SELECT @id = ID FROM " + table + " WHERE name = @name; " +
                "END";

            List<int> entityIds = new List<int>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand insert = new SqlCommand(insertCommand, con))
                {
                    insert.Parameters.Add("@name", System.Data.SqlDbType.NVarChar);
                    insert.Parameters.Add("@id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

                    foreach (String name in entities)
                    {
                        insert.Parameters["@name"].Value = name;

                        insert.ExecuteNonQuery();
                        entityIds.Add((int)insert.Parameters["@id"].Value);
                    }
                }
            }

            return entityIds;
        }

        private void LinkMovieAnd(String table, int movieId, List<int> entityIds)
        {
            String insertCommand = "INSERT INTO movies_" + table + "s( movieId, " + table + "Id) " +
                "VALUES( @movieId, @entityId);";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand insert = new SqlCommand(insertCommand, con))
                {
                    insert.Parameters.Add("@movieId", System.Data.SqlDbType.Int);
                    insert.Parameters.Add("@entityId", System.Data.SqlDbType.Int);

                    insert.Parameters["@movieId"].Value = movieId;

                    foreach (int entityId in entityIds)
                    {
                        insert.Parameters["@entityId"].Value = entityId;

                        try
                        {
                            insert.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        { }
                    }
                }
            }
        }

    }
}