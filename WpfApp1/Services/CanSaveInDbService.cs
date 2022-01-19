using BLToolkit.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.Data;
using WpfApp1.Data.Models;
using WpfApp1.Models;

namespace WpfApp1
{
    public class CanSaveInDbService : ICanSaveService
    {
        public void Save(PersonModel personModel)
        {
            using (DbManager db = new DbManager())
            {

                var cs = ConfigurationManager.ConnectionStrings["DemoConnection"];
                DbManager.AddConnectionString(cs.ConnectionString);

                db
                .SetSpCommand("InsertPerson",
                    db.Parameter("@FirstName", personModel.FirstName),
                    db.Parameter("@LastName", personModel.LastName),
                    db.Parameter("@Salary", personModel.Salary))
                .ExecuteObject<PersonModel>();
            }
        }


        //private readonly AppDbContext _db;

        //public CanSaveInDbService (AppDbContext db)
        //{
        //    _db = db;
        //}

        //public void Save(PersonModel personModel)
        //{
        //    var entity = new Person()
        //    {
        //        FirstName = personModel.FirstName,
        //        LastName = personModel.LastName,
        //        Salary = personModel.Salary,
        //    };
        //    _db.Person.Add(entity);
        //    _db.SaveChanges();
        //}

    }
}
