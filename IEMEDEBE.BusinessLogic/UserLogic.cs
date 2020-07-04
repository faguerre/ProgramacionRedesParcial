using IEMEDEBE.BusinessLogic.Interface;
using IEMEDEBE.Domain;
using IEMEDEBE.Domain.Utils;
using IEMEDEBE.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private IUnitOfWork unitOfWork;
        public UserLogic(IUnitOfWork _unitOfWork) {
            unitOfWork = _unitOfWork;
        }

        public Result<User> AddFavouriteMovie(string nickName, string movie)
        {
            throw new NotImplementedException();
        }

        public Result<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Result<User> DeleteFavouriteMovie(string nickName, string movie)
        {
            throw new NotImplementedException();
        }

        public Result<User> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Result<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Result<User> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
