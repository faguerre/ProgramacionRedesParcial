using IEMEDEBE.BusinessLogic.Interface;
using IEMEDEBE.Domain;
using IEMEDEBE.Domain.Security;
using IEMEDEBE.Domain.Utils;
using IEMEDEBE.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.BusinessLogic
{
    public class SessionLogic : ISessionLogic
    {
        IUnitOfWork _UnitOfWork;

        public SessionLogic(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public Result<Session> isLogged(Guid actualtoken)
        {
            Session active = this._UnitOfWork.SessionRepository.Get(x => x.Token == actualtoken);
            if (active == null)
            {
                return new Result<Session>
                {
                    ResultObject = active,
                    Message = ""
                };
            }
            else
            {
                return new Result<Session>
                {
                    ResultObject = null,
                    Message = "No user logged in with the id"
                };
            }
        }

        public Result<Session> Login(string nick, string password)
        {
            User user = _UnitOfWork.UserRepository.Get(x => x.NickName.Equals(nick) && x.Password.Equals(password));
            if (user != null)
            {
                Session newSession = new Session() { User = user, Token = Guid.NewGuid() };
                this._UnitOfWork.SessionRepository.Add(newSession);
                this._UnitOfWork.SessionRepository.Save();
                Result<Session> result = new Result<Session>()
                {
                    ResultObject = newSession,
                    Message = newSession.Token.ToString()
                };
                return result;
            }
            else
            {
                return new Result<Session>()
                {
                    ResultObject = null,
                    Message = "There is no user related to this credentials"
                };
            }
        }

        public Result<Session> Logout(string nick)
        {
            Session sessionRelated = this._UnitOfWork.SessionRepository.Get(x => x.User.NickName.Equals(nick));
            if (sessionRelated != null)
            {
                this._UnitOfWork.SessionRepository.Delete(sessionRelated);
                return new Result<Session>()
                {
                    ResultObject = new Session(),
                    Message = "GoodBye"
                };
            }
            else
            {
                return new Result<Session>()
                {
                    ResultObject = null,
                    Message = "There is no user related to this credentials"
                };
            }
        }
    }
}
