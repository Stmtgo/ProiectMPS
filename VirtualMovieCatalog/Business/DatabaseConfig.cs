using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Configuration;

namespace VirtualMovieCatalog.Business
{
    public class DatabaseConfig
    {
        //Data Members=============================================================================
        private const string USERNAME = "Username";
        private const string PASSWORD = "Password";
        private const string DATABASE = "Database";
        private const string SERVER = "Server";

        //Constructor(s)===========================================================================
        public DatabaseConfig()
        {
        }


        //Public Methods===========================================================================
        public string GetUsername()
        {
            return ConfigurationManager.ConnectionStrings[USERNAME].ConnectionString;
        }

        public string GetPassword()
        {
            return ConfigurationManager.ConnectionStrings[PASSWORD].ConnectionString;
        }

        public string GetDatabase()
        {
            return ConfigurationManager.ConnectionStrings[DATABASE].ConnectionString;
        }

        public string GetServer()
        {
            return ConfigurationManager.ConnectionStrings[SERVER].ConnectionString;
        }
    }
}
