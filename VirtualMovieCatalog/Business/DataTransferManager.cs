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
        private String connectionString = null;

        public DataTransferManager( String user, String password, String server, String database)
        {
            connectionString = "Data Source=(LocalDb)\\v11.0;AttachDbFilename=|DataDirectory|\\movies.mdf;Initial Catalog=movies;Integrated Security=True";
        }

        public List<String> getMovies()
        {
            var ret = new List<String>();

            String selectCommand = "SELECT * FROM movies";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string path;
                path = System.IO.Path.GetDirectoryName(
                   System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

                con.Open();

                using (SqlCommand select = new SqlCommand(selectCommand, con))
                {

                    var result = select.ExecuteReader();

                    while (result.Read())
                    {
                        ret.Add(result["name"].ToString());
                    }
                }
            }

            return ret;
        }

        public bool insertMovie( Movie movie)
        {
            var status = true;

            using ( var scope = new System.Transactions.TransactionScope())
            {
                try {
                    int insertedId = addMovie( movie.Name, movie.Descripsion, movie.Year, movie.NrDiscs);
                    
                    List<int> directorIds = add( "directors", movie.Directors);
                    List<int> genreIds = add( "genres", movie.Genres);
                    List<int> subtitleIds = add( "subtitlesLang", movie.Subtitles);
                    List<int> actorIds = add( "actors", movie.Actors);

                    linkMovieAnd( "director", insertedId, directorIds);
                    linkMovieAnd( "genre", insertedId, genreIds);
                    linkMovieAnd( "subtitle", insertedId, subtitleIds);
                    linkMovieAnd( "actor", insertedId, actorIds);
                    
                    // commits the changes to the database
                    scope.Complete();

                } catch (Exception e) {
                    status = false;
                }
            }

            return status;
        }


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

            List<int> directorIds = new List<int>();

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
                        directorIds.Add( (int)insert.Parameters["@id"].Value);
                    }
                }
            }

            return directorIds;
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
