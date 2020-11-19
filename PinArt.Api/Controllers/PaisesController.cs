using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PinArt.Api.Responses;
using PinArt.Core.DTOs.Pais;
using PinArt.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PinArt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPaisService _PaisesService;

        public PaisesController(IMapper mapper, IPaisService paisesService)
        {
            this._PaisesService = paisesService;
            this._mapper = mapper;
        }

        // GET: /artistas
        [HttpGet]
        public async Task<IActionResult> GetAllPaises()
        {
            var paises = await _PaisesService.GetPaises();
            var PaisesDto = _mapper.Map<IEnumerable<GetPaisDto>>(paises);

            var response = new ApiResponse<IEnumerable<GetPaisDto>>(PaisesDto);
            response.success = true;
            response.Message = "Listado de Paises";

            return Ok(response);
        }
    }
}
