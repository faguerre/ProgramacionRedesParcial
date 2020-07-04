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
        private DbContext Context;

        public UserRepository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public void Add(User entity)
        {
            Context.Set<User>().Add(entity);
        }

        public void Delete(User entity)
        {
            Context.Set<User>().Remove(entity);
        }

        public bool Exist(Func<User, bool> predicate)
        {
            return Context.Set<User>().FirstOrDefault(predicate) == null;
        }

        public User Get(Func<User, bool> predicate)
        {
            User userToreturn = null;
            userToreturn = Context.Set<User>().FirstOrDefault(predicate);
            return userToreturn;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> returnListFromDB = Context.Set<User>().ToList();
            return returnListFromDB;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(User entity)
        {
            Context.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
