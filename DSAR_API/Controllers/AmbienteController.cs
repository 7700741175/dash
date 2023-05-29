using System;
using Dash_API.Business;
using System.Web.Http;
using RouteAttribute = System.Web.Http.RouteAttribute;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using System.Collections.Generic;
using Dash_API.Models;

namespace Dash_API.Controllers
{
    public class AmbienteController : ApiController
    {
        [Route("api/Deploy")]
        [Authorize]
        public IHttpActionResult Get([FromUri]  String NomeAmbiente)
        {
            try
            {
                return Ok(AmbienteBll.RetornaDeploy(NomeAmbiente));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Route("api/Ambiente")]
        [Authorize]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(AmbienteBll.RetornaAmbiente());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}