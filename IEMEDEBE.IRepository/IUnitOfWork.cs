using IEMEDEBE.Domain;
using IEMEDEBE.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.IRepository
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Session> SessionRepository { get; }
    }
}
