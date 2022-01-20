using BLToolkit.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace WpfApp1.Data
{
    public class DbManagerFactory : IDbManagerFactory
    {
        private const string connectionString = "Server=QUINB016787\\SQLEXPRESS;Database=TextDb;Integrated Security=true;";
        public DbManagerFactory()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["DemoConnection"];
            DbManager.AddConnectionString(connectionString);
        }
        public DbManager GetDbManager()
        {
            return new DbManager();
        }
    }
    
   

    
}
