using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces;
using RentACar.Application.ViewModels;

namespace RentACar.Services.Api.Controllers
{    
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("api/v1/marca")]
    [Produces("application/json")]
    public class MarcaController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMarcaAppService _marcaAppService;

        public MarcaController(IMapper mapper, IMarcaAppService marcaAppService)
        {
            _mapper = mapper;
            _marcaAppService = marcaAppService;
        }

        [Authorize()]
        [HttpGet()]
        public async Task<IEnumerable<MarcaViewModel>> GetAll()
        {
            return await _marcaAppService.GetAll();
        }

        [Authorize()]
        [HttpGet("{id:guid}")]
        public async Task<MarcaViewModel> GetById(Guid id)
        {
            return await _marcaAppService.GetById(id);
        }

        [Authorize()]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]MarcaInsertViewModel insertViewModel)
        {
            var marcaViewModel = _mapper.Map<MarcaViewModel>(insertViewModel);
            var result = _marcaAppService.Insert(marcaViewModel);            

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(result);
        }

        [Authorize()]
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody]MarcaUpdateViewModel updateViewModel)
        {
            var marcaViewModel = _mapper.Map<MarcaViewModel>(updateViewModel);
            var result = _marcaAppService.Update(marcaViewModel);            

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(result);
        }

        [Authorize()]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _marcaAppService.Delete(id);

            return CustomResponse();
        }
    }
}
