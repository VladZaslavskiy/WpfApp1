using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Services
{
    public interface IOutFromDbService
    {
        public IList<T> GetItemList<T>(string storedProcedure, T model);
    }
}
