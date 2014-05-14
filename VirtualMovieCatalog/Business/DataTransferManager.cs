using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace VirtualMovieCatalog.Business
{
    class DataTransferManager
    {
        private String connectionString = null;

        public DataTransferManager( String user, String password, String server, String database)
        {
            connectionString = "user id=oregano;" +
                                 "password=oregano;" +
                                 "server=GPC\\SQLEXPRESS;" +
                                 "Trusted_Connection=yes;" +
                                 "database=movie_db; " +
                                 "connection timeout=10";
        }

        public bool addMovie( String name, String description, int year, int nrDiscs)
        {
            String insertCommand = "INSERT INTO movies( name, description, year, nrDiscs) " +
                                   "VALUES ( @name, @description, @year, @nrDiscs)";

            try
            {
                using (SqlConnection con = new SqlConnection( connectionString))
                {
                    con.Open();

                    using (SqlCommand insert = new SqlCommand( insertCommand, con))
                    {
                        insert.Parameters.AddWithValue( "@name", name);
                        insert.Parameters.AddWithValue( "@description", description);
                        insert.Parameters.AddWithValue( "@year", year);
                        insert.Parameters.AddWithValue( "@nrDiscs", nrDiscs);

                        insert.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }



    }
}
