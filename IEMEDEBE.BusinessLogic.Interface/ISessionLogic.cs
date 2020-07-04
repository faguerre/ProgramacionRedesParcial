using IEMEDEBE.Domain.Security;
using IEMEDEBE.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.BusinessLogic.Interface
{
    public interface ISessionLogic
    {
        Result<Session> Login(string nick, string password);
        Result<Session> Logout(string nick);
        Result<Session> isLogged(Guid actualtoken);
    }
}
