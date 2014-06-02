using System;
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
        {}

        //Public Methods===========================================================================

        // filter can take the following values:
        // name, year, nrdiscs, genre, actor, director, disc, ""
        public List<Movie> getMovies( String filter, String value)
        {
            List<int> movieIds = getMovieIds(filter, value);
            return getMoviesByIds( movieIds);
        }

        public bool insertMovie(Movie movie)
        {
            var status = true;

            using (var transaction = new System.Transactions.TransactionScope())
            {
                try
                {
                    int insertedId = addMovie(movie.Name, movie.Descripsion, movie.Year, movie.NrDiscs);

                    List<int> directorIds = add("directors", movie.Directors);
                    List<int> genreIds = add("genres", movie.Genres);
                    List<int> subtitleIds = add("subtitlesLang", movie.Subtitles);
                    List<int> actorIds = add("actors", movie.Actors);
                    List<int> discIds = add("discs", movie.Discs);

                    linkMovieAnd("director", insertedId, directorIds);
                    linkMovieAnd("genre", insertedId, genreIds);
                    linkMovieAnd("subtitle", insertedId, subtitleIds);
                    linkMovieAnd("actor", insertedId, actorIds);
                    linkMovieAnd("disc", insertedId, discIds);

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



        //Private Methods==========================================================================
        private List<int> getMovieIds(String filter, String value)
        {
            List<int> movieIds = null;

            switch (filter) 
            {
                case "name": case "year": case "nrdiscs":
                    movieIds = simpleQuery(filter, value);
                    break;
                case "genre": case "actor": case "director": case "disc":
                    movieIds = complexQuery(filter, value);
                    break;
                default:
                    movieIds = allQuery();
                    break;
            }

            return movieIds;
        }

        private List<int> allQuery()
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
        private List<int> simpleQuery(String property, String value)
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
        private List<int> complexQuery( String property, String value)
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

        private List<Movie> getMoviesByIds(List<int> movieIds)
        {
            List<Movie> movies = new List<Movie>();

            foreach (int id in movieIds)
            {
                Dictionary<String, String> movieComponents = getMovieBasicComponents(id);
                
                List<string> directors = getById("director", id);
                List<string> actors = getById("actor", id);
                List<string> genres = getById("genre", id);
                List<string> subtitles = getById("subtitle", id);
                List<string> discs = getById("disc", id);

                Movie movie = new Movie(movieComponents["name"], genres, directors, actors, subtitles, discs, movieComponents["description"], Convert.ToInt32(movieComponents["year"]), Convert.ToInt32(movieComponents["nrDiscs"]));
                movies.Add(movie);
            }

            return movies;
        }

        private Dictionary<String, String> getMovieBasicComponents(int id)
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

        private List<String> getById(String table, int id)
        {
            // no need to prepare for SQL INJECTION here (data is sanitized)
            String selectComand = "SELECT D.name name FROM " + table + "s D " +
                                  "INNER JOIN movies_" + table + "s M ON " + 
                                  "D.id = M." + table + "id AND M.movieid = " + id;
            
            List<String> result = new List<String>();

            using (SqlConnection con = new SqlConnection(connectionString)) {
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
        private int addMovie( String name, String description, int year, int nrDiscs)
        {

            int id;

            String insertCommand = "INSERT INTO movies( name, description, year, nrDiscs) " +
                                   "VALUES ( @name, @description, @year, @nrDiscs); " +
                                   "SELECT SCOPE_IDENTITY();";

            using (SqlConnection con = new SqlConnection( connectionString))
            {
                con.Open();

                using (SqlCommand insert = new SqlCommand( insertCommand, con))
                {
                    insert.Parameters.AddWithValue( "@name", name);
                    insert.Parameters.AddWithValue( "@description", description);
                    insert.Parameters.AddWithValue( "@year", year);
                    insert.Parameters.AddWithValue( "@nrDiscs", nrDiscs);

                    id = Convert.ToInt32( insert.ExecuteScalar());
                }
            }

            return id;
        }

        /**
         * Adds all the @entities to the @table and returns the resulting ids
         */
        private List<int> add( String table, List<String> entities) 
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

            using (SqlConnection con = new SqlConnection( connectionString))
            {
                con.Open();

                using (SqlCommand insert = new SqlCommand( insertCommand, con))
                {
                    insert.Parameters.Add("@name", System.Data.SqlDbType.NVarChar);
                    insert.Parameters.Add("@id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    
                    foreach ( String name in entities) 
                    {
                        insert.Parameters["@name"].Value = name;

                        insert.ExecuteNonQuery();
                        entityIds.Add( (int)insert.Parameters["@id"].Value);
                    }
                }
            }

            return entityIds;
        }

        private void linkMovieAnd( String table, int movieId, List<int> entityIds)
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
                        } catch (Exception e) 
                        {}
                    }
                }
            }
        }

    }
}
