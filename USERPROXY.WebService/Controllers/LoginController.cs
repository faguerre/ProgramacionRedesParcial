using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using USERPROXY.WebService.Models;

namespace USERPROXY.WebService.Controllers
{
    [RoutePrefix("login")]
    public class LoginController : ApiController
    {

        private string url = "";
        private HttpClient httpClient;

        public LoginController() {
        

        }


        [Route("")]
        public async Task<HttpResponseMessage> Login([FromBody] LoginModel loginModel) {

            try
            {
                HttpResponseMessage response = await this.httpClient.PostAsJsonAsync(url, loginModel);

                if (response.IsSuccessStatusCode) {
                   
                }

                return response;
            }
            catch (Exception e){
                throw new Exception(e.Message);
            }
        }

    }
}
