using IEMEDEBE.Domain;
using IEMEDEBE.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.Repository
{
    public class UserRepository : IRepository<User>
    {
        private DbContext dbContext;

        public UserRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Exist(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public User Get(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
