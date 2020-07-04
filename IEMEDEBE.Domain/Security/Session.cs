using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.Domain.Security
{
    public class Session
    {
        public User User { get; set; }
        public Guid Token { get; set; }

        public Session(User _user, Guid _token)
        {

            this.User = _user;
            this.Token = _token;
        }

        public Session()
        {
            Token = new Guid();
        }
    }
}
