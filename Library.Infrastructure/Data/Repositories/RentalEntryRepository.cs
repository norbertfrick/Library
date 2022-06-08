using Library.Core.Abstractions;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.Repositories
{
    public class RentalEntryRepository : IRentalEntryRepository
    {
        public RentalEntry Create(RentalEntry entity)
        {
            throw new NotImplementedException();
        }

        public RentalEntry Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RentalEntry> Find(Expression<Func<RentalEntry, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RentalEntry> GetAll()
        {
            throw new NotImplementedException();
        }

        public RentalEntry GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, RentalEntry entity)
        {
            throw new NotImplementedException();
        }
    }
}
