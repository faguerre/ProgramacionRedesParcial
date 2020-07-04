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

        IEnumerable<User> IUserLogic.GetAll()
        {
            return unitOfWork.UserRepository.GetAll();
        }

        public Result<User> GetUser(int id)
        {
            User user = unitOfWork.UserRepository.Get(x => x.Id == id);
            if (user == null)
            {
                return new Result<User>()
                {
                    ResultObject = null,
                    Message = "There is no user related to the id" + id
                };
            }

            return new Result<User>()
            {
                ResultObject = user,
                Message = null
            };
        }
        public Result<User> AddUser(User _user)
        {
            if (ExistsNickName(_user.NickName))
            {
                return new Result<User>()
                {
                    ResultObject = null,
                    Message = "already exist an user with the nickname"
                };
            }
            else
            {
                unitOfWork.UserRepository.Add(_user);
                unitOfWork.UserRepository.Save();
                return new Result<User>()
                {
                    ResultObject = _user,
                    Message = null
                };
            }
        }
        private bool ExistsNickName(string nickName)
        {
            User user = unitOfWork.UserRepository.Get(x => x.NickName == nickName);
            return (user != null);
        }

        public Result<User> DeleteUser(int id)
        {
            try
            {
                User userToDelete = unitOfWork.UserRepository.Get(x => x.Id == id);
                if (userToDelete != null)
                {
                    unitOfWork.UserRepository.Delete(userToDelete);
                    unitOfWork.UserRepository.Save();
                    return new Result<User>()
                    {
                        ResultObject = userToDelete,
                        Message = "User removed succesfully"
                    };
                }
                else
                {
                    return new Result<User>()
                    {
                        ResultObject = null,
                        Message = "There are no user related to the id " + id
                    };
                }
            }
            catch (ArgumentException e)
            {
                return new Result<User>()
                {
                    ResultObject = null,
                    Message = e.Message
                };
            }

        }

        public Result<User> UpdateUser(int id, User user)
        {
            try
            {
                User userAux = unitOfWork.UserRepository.Get(x => x.Id == id);
                if (userAux == null)
                {
                    return new Result<User>()
                    {
                        ResultObject = null,
                        Message = "There is no user related to this id" + id
                    };
                }
                else
                {
                    if (ExistsNickName(user.NickName) && !userAux.NickName.Equals(user.NickName))
                    {
                        return new Result<User>()
                        {
                            ResultObject = null,
                            Message = "Already exist an user with this id"
                        };
                    }
                    else
                    {
                        unitOfWork.UserRepository.Update(user);
                        unitOfWork.UserRepository.Save();
                        return new Result<User>()
                        {
                            ResultObject = user,
                            Message = null
                        };
                    }
                }
            }
            catch (ArgumentException e)
            {
                return new Result<User>()
                {
                    ResultObject = null,
                    Message = e.Message
                };
            }
        }

        public Result<User> AddFavouriteMovie(string nickName, string movie)
        {
            try
            {
                User _user = unitOfWork.UserRepository.Get(x => x.NickName == nickName);
               // Movie _movie = _UnitOfWork.MovieRepository.Get(x => x.Name.Equals(movie));
               Movie _movie = null;
                if (_user.IsFavouriteMovie(_movie))
                {
                    return new Result<User>()
                    {
                        ResultObject = null,
                        Message = "The user already have this movie as favourite"
                    };
                }
                else
                {
                    _user.AddFavouriteMovie(_movie);
                    unitOfWork.UserRepository.Save();
                    return new Result<User>()
                    {
                        ResultObject = _user,
                        Message = ""
                    };
                }
            }
            catch (ArgumentException e)
            {
                return new Result<User>()
                {
                    ResultObject = null,
                    Message = e.Message
                };
            }
        }

        public Result<User> DeleteFavouriteMovie(string nickName, string movie)
        {
            try
            {
                User _user = unitOfWork.UserRepository.Get(x => x.NickName == nickName);
                // Movie _movie = _UnitOfWork.MovieRepository.Get(x => x.Name.Equals(movie));
                Movie _movie = null;
                if (_user.IsFavouriteMovie(_movie))
                {
                    _user.DeleteFavouriteMovie(_movie);
                    unitOfWork.UserRepository.Save();
                    return new Result<User>()
                    {
                        ResultObject = _user,
                        Message = ""
                    };
                }
                else
                {
                    return new Result<User>()
                    {
                        ResultObject = null,
                        Message = "The movie selected wasnt selected as favourite by the user"
                    };
                }
            }
            catch (ArgumentException e)
            {
                return new Result<User>()
                {
                    ResultObject = null,
                    Message = e.Message
                };
            }

        }
    }
}
