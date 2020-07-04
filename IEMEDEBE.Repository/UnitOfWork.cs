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
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext dbContext;
        private IRepository<User> userRepository;


        public UnitOfWork(DbContext _dbContext) {
            dbContext = _dbContext;
        }

        public IRepository<User> UserRepository {
            get {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(dbContext);
                }

                return userRepository;
            }
        }
    }
}
