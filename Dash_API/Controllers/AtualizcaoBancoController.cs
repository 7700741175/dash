using Dash_API.Business;
using Dash_API.Utils;
using System;
using System.Web.Http;
using System.Web.Mvc;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace Dah_API.Controllers
{
    public class AtualizcaoBancoController : ApiController
    {
        [Route("api/AtualizacaoBanco")]
        [Authorize]
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(AtualizacaoBancoBll.GetAtualizacaoBancos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}