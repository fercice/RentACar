using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Services.Api.Authentication;
using System.Net;

namespace RentACar.Services.Api.Controllers
{
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/v1/autenticar")]
    [Produces("application/json")]
    public class AutenticarController : ApiController
    {
        [HttpPost]
        [Route("gerar-token")]
        public ActionResult<dynamic> GenerateToken()
        {
            return Ok(new { token = TokenService.GenerateToken()} );
        }
    }
}
