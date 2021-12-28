using System;
using System.Collections.Generic;
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
        private readonly AppDbContext _db;

        public CanSaveInDbService (AppDbContext db)
        {
            _db = db;
        }

        public async Task Save(PersonModel personModel, CancellationToken cancellationToken)
        {
            var entity = new Person()
            {
                FirstName = personModel.FirstName,
                LastName = personModel.LastName,
                Salary = personModel.Salary,
            };
            _db.Persons.Add(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
