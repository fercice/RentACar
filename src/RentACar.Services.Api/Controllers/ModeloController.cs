using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces;
using RentACar.Application.ViewModels;

namespace RentACar.Services.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/v1/modelo")]
    [Produces("application/json")]
    public class ModeloController : ApiController
    {
        private readonly IModeloAppService _modeloAppService;

        public ModeloController(IModeloAppService modeloAppService)
        {            
            _modeloAppService = modeloAppService;
        }

        [Authorize()]
        [HttpGet()]
        public async Task<IEnumerable<ModeloViewModel>> GetAll()
        {
            return await _modeloAppService.GetAll();
        }

        [Authorize()]
        [HttpGet("{id:guid}")]
        public async Task<ModeloViewModel> GetById(Guid id)
        {
            return await _modeloAppService.GetById(id);
        }

        [Authorize()]
        [HttpGet("pormarca/{id:guid}")]
        public async Task<IEnumerable<ModeloViewModel>> BuscarModelosPorMarca(Guid id)
        {
            return await _modeloAppService.BuscarModelosPorMarca(id);
        }

        [Authorize()]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]ModeloInsertViewModel insertViewModel)
        {
            var result = await _modeloAppService.Insert(insertViewModel);

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(result);
        }

        [Authorize()]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody]ModeloUpdateViewModel updateViewModel)
        {
            var result = await _modeloAppService.Update(updateViewModel);

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(result);
        }

        [Authorize()]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _modeloAppService.Delete(id);

            return CustomResponse();
        }
    }
}
