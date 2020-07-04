using IEMEDEBE.Domain;
using IEMEDEBE.Domain.Security;
using IEMEDEBE.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.Repository
{
    public class SessionRepository : IRepository<Session>
    {
        private DbContext Context;

        public SessionRepository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public void Add(Session entity)
        {
            Context.Set<Session>().Add(entity);
        }

        public void Delete(Session entity)
        {
            Context.Set<Session>().Remove(entity);
        }

        public bool Exist(Func<Session, bool> predicate)
        {
            return Context.Set<Session>().FirstOrDefault(predicate) == null;
        }

        public Session Get(Func<Session, bool> predicate)
        {
            Session userToreturn = null;
            userToreturn = Context.Set<Session>().FirstOrDefault(predicate);
            return userToreturn;
        }

        public IEnumerable<Session> GetAll()
        {
            IEnumerable<Session> returnListFromDB = Context.Set<Session>().ToList();
            return returnListFromDB;
        }

        public void Update(Session entity)
        {
            Context.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
