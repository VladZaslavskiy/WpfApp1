using BLToolkit.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using WpfApp1.Data;

namespace WpfApp1.Services
{
    public class OutputtingDbService : IOutFromDbService
    {

        private readonly IDbManagerFactory _dbManagerFactory;

        public OutputtingDbService(IDbManagerFactory dbManagerFactory)
        {
            _dbManagerFactory = dbManagerFactory;
        }
        public IList<T> GetItemList<T>(string storedProcedure, T model)
        {

            using (DbManager db = _dbManagerFactory.GetDbManager())
            {
                               
                return db
                    .SetSpCommand(storedProcedure)
                    .ExecuteList<T>();
            }
        }
    }
}
