using IEMEDEBE.AdminWebService.Models;
using IEMEDEBE.BusinessLogic.Interface;
using IEMEDEBE.Domain;
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
    [RoutePrefix("users")]
    public class UserController : ApiController
    {
        private IUserLogic userLogic;

        public UserController(IUserLogic _UserLogic)
        {
            userLogic = _UserLogic;
        }

        [Route("{id}", Name = "GetUserById")]
        public async Task<IHttpActionResult> Get(int id)
        {

            try
            {
                await Task.Yield();
                Result<User> result = this.userLogic.GetUser(id);
                if (result.ResultObject != null)
                {
                    return Ok(result.ResultObject);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {

            try
            {
                await Task.Yield();
                IEnumerable<User> userList = this.userLogic.GetAll();
                if (userList.Count() == 0)
                {
                    return Ok("No users availables");
                }
                else
                {
                    return Ok(userList);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]UserModel userModel)
        {
            try
            {
                await Task.Yield();
                Result<User> result = this.userLogic.AddUser(userModel.ToEntity());
                if (result.ResultObject != null)
                {
                    return CreatedAtRoute("GetUserById", new { id = result.ResultObject.Id }, $"New user created with the id " + result.ResultObject.Id);
                }
                else
                {
                    return BadRequest(result.Message);
                }

            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (NullReferenceException e)
            {
                return BadRequest("User is null");
            }

        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]UserModel userModel)
        {
            try
            {
                await Task.Yield();
                Result<User> result = this.userLogic.UpdateUser(id, userModel.ToEntity());
                if (result.ResultObject != null)
                {
                    return CreatedAtRoute("GetUserById", new { id = result.ResultObject.Id }, $" User updated with the id " + result.ResultObject.Id);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }


        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await Task.Yield();
                Result<User> result = this.userLogic.DeleteUser(id);
                if (result.ResultObject != null)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("addfavourite")]
        public async Task<IHttpActionResult> AddFavouriteMovie([FromBody] UserFavMovieModel movie_favourite)
        {
            try
            {
                await Task.Yield();
                Result<User> result = this.userLogic.AddFavouriteMovie(movie_favourite.NickName, movie_favourite.MovieName);
                if (result.ResultObject != null)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("removefavourite")]
        public async Task<IHttpActionResult> RemoveFavouriteMovie([FromBody]UserFavMovieModel movie_favourite)
        {
            try
            {
                await Task.Yield();
                Result<User> result = this.userLogic.DeleteFavouriteMovie(movie_favourite.NickName, movie_favourite.MovieName);
                if (result.ResultObject != null)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest(result.Message);
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
