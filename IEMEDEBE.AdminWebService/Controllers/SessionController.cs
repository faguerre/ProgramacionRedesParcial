using IEMEDEBE.AdminWebService.Models;
using IEMEDEBE.BusinessLogic.Interface;
using IEMEDEBE.Domain.Security;
using IEMEDEBE.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace IEMEDEBE.AdminWebService.Controllers
{
    
    [RoutePrefix("sessions")]
    public class SessionController : ApiController
    {
        private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);
        private ISessionLogic sessionLogic;

        public SessionController(ISessionLogic _sessionnLogic)
        {
            sessionLogic = _sessionnLogic;
        }

        [Route("")]
        public async Task<IHttpActionResult> Login([FromBody]LoginModel _loginModel)
        {
            await SemaphoreSlim.WaitAsync();
            try
            {
                await Task.Yield();
                Result<Session> tokenCreated = this.sessionLogic.Login(_loginModel.NickName, _loginModel.Password);
                if (tokenCreated.ResultObject != null)
                {
                    return Ok(tokenCreated.Message);
                }
                else {
                    return BadRequest(tokenCreated.Message);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }

        [Route("logout")]
        public async Task<IHttpActionResult> Logout([FromBody]LoginModel logout)
        {
            await SemaphoreSlim.WaitAsync();
            try
            {
                await Task.Yield();
                Result<Session> tokenCreated = this.sessionLogic.Logout(logout.NickName);
                if (tokenCreated != null)
                {
                    if (tokenCreated.ResultObject.Token != null)
                    {
                        return Ok("GoodBye!");
                    }
                    else
                    {
                        return BadRequest(tokenCreated.Message);
                    }
                }
                else
                {
                    return BadRequest("There is no user logged in");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            finally
            {
                SemaphoreSlim.Release();
            }
        }
    }
}
