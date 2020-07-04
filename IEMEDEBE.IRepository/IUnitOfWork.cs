using IEMEDEBE.Domain;
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
    }
}
