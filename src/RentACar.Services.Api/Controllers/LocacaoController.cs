using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces;
using RentACar.Application.ViewModels;

namespace RentACar.Services.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/v1/locacao")]
    [Produces("application/json")]
    public class LocacaoController : ApiController
    {
        private readonly ILocacaoAppService _locacaoAppService;

        public LocacaoController(ILocacaoAppService locacaoAppService)
        {
            _locacaoAppService = locacaoAppService;
        }

        [Authorize()]
        [HttpPost("simulacao")]
        public async Task<IActionResult> Post([FromBody]SimulacaoConsultaViewModel model)
        {
            var result = await _locacaoAppService.Simulacao(model);

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(result);
        }
    }
}
