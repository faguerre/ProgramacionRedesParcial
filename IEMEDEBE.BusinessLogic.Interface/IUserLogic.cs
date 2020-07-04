using IEMEDEBE.Domain;
using IEMEDEBE.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.BusinessLogic.Interface
{
    public interface IUserLogic
    {
        IEnumerable<User> GetAll();
        Result<User> GetUser(int id);
        Result<User> AddUser(User user);
        Result<User> DeleteUser(int id);
        Result<User> UpdateUser(int id, User user);
        Result<User> AddFavouriteMovie(string nickName, string movie);
        Result<User> DeleteFavouriteMovie(string nickName, string movie);
    }
}
