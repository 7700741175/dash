using Dash_API.Business;
using Dash_API.Utils;
using DSAR_API.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web.Configuration;
using System.Web.Http;

namespace Dash_API.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/auth")]
        public IHttpActionResult Get()
        {
            try
            {
                TokenDto Retorno = new TokenDto();
                Retorno.Token = TokenHandle.createToken();
                return Ok(Retorno);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        
    }
}