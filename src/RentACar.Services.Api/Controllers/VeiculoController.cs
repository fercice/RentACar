using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces;
using RentACar.Application.ViewModels;

namespace RentACar.Services.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/v1/veiculo")]
    [Produces("application/json")]
    public class VeiculoController : ApiController
    {
        private readonly IVeiculoAppService _veiculoAppService;

        public VeiculoController(IVeiculoAppService veiculoAppService)
        {
            _veiculoAppService = veiculoAppService;
        }

        [Authorize()]
        [HttpGet()]
        public async Task<IEnumerable<VeiculoViewModel>> GetAll()
        {
            return await _veiculoAppService.GetAll();
        }

        [Authorize()]
        [HttpGet("{id:guid}")]
        public async Task<VeiculoViewModel> GetById(Guid id)
        {
            return await _veiculoAppService.GetById(id);
        }

        [Authorize()]
        [HttpGet("pormarca/{id:guid}")]
        public async Task<IEnumerable<VeiculoViewModel>> BuscarVeiculosPorMarca(Guid id)
        {
            return await _veiculoAppService.BuscarVeiculosPorMarca(id);
        }

        [Authorize()]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] VeiculoInsertViewModel insertViewModel)
        {
            var result = await _veiculoAppService.Insert(insertViewModel);

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(result);
        }

        [Authorize()]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] VeiculoUpdateViewModel updateViewModel)
        {
            var result = await _veiculoAppService.Update(updateViewModel);

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(result);
        }

        [Authorize()]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _veiculoAppService.Delete(id);

            return CustomResponse();
        }
    }
}
