using BLToolkit.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.Data
{
    public interface IDbManagerFactory
    {
        public DbManager GetDbManager();
    }
}
