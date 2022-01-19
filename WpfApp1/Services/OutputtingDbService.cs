using BLToolkit.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace WpfApp1.Services
{
    public class OutputtingDbService : IOutFromDbService
    {
        
        public IList<T> GetItemList<T>(string storedProcedure, T model)
        {

            using (DbManager db = new DbManager())
            {

                var cs = ConfigurationManager.ConnectionStrings["DemoConnection"];
                DbManager.AddConnectionString(cs.ConnectionString);

                return db
                    .SetSpCommand(storedProcedure)
                    .ExecuteList<T>();
            }
        }
    }
}
