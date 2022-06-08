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
    public class MemberRepository : IMemberRepository
    {
        public Member Create(Member entity)
        {
            throw new NotImplementedException();
        }

        public Member Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> Find(Expression<Func<Member, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetAll()
        {
            throw new NotImplementedException();
        }

        public Member GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Member entity)
        {
            throw new NotImplementedException();
        }
    }
}
