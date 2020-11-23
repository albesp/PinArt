using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PinArt.Api.Responses;
using PinArt.Core.DTOs.Artista;
using PinArt.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinArt.Core.Entities;
using PinArt.Core.Exceptions;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PinArt.Infrastructure.Filters;

namespace PinArt.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IArtistaService _ArtistasService;        

        public ArtistasController(IMapper mapper, IArtistaService artistasService)
        {
            this._ArtistasService = artistasService;
            this._mapper = mapper;            
        }

        /// <summary>
        /// Retrieve all posts
        /// </summary>
        
        // GET: /artistas
        [HttpGet]
        public async Task<IActionResult> GetAllArtistas()
        {  
            var artistas = await _ArtistasService.GetArtistas();
            var ArtistasDto = _mapper.Map<IEnumerable<GetArtistaDto>>(artistas);

            var response = new ApiResponse<IEnumerable<GetArtistaDto>>(ArtistasDto);
            response.success = true;
            response.Message = "Listado de Artistas";

            return Ok(response);
        }

        // GET: /artistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetArtistaDto>> GetArtistaById(int id)
        {
            var artista = await _ArtistasService.GetArtista(id);

            if (artista == null)
            {
                throw new NotFoundException("No Existe el Artista Id: " + id);
            }

            var artistaDto = _mapper.Map<GetArtistaDto>(artista);
            var response = new ApiResponse<GetArtistaDto>(artistaDto);
            response.success = true;
            return Ok(response);
        }

        //POST: movies       
        [HttpPost]
        public async Task<IActionResult> InsertArtista([FromBody] SaveArtistaDto saveArtistaDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    var message = string.Join(" | ", ModelState.Values
            //                        .SelectMany(v => v.Errors)
            //                        .Select(e => e.ErrorMessage));
            //    throw new ModelStateException( "The Model Is Not Valid: " + message);
            //}
                

            var artista = _mapper.Map<Artista>(saveArtistaDto);

            await _ArtistasService.InsertArtista(artista);

            artista = await _ArtistasService.GetArtista(artista.Id);

            var ArtistaDto = _mapper.Map<GetArtistaDto>(artista);

            var response = new ApiResponse<GetArtistaDto>(ArtistaDto);
            response.success = true;
            response.Message = "El Registro Ha Sido Ingresado";

            return Ok(response);
        }

        //PUT: artistas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] SaveArtistaDto saveArtistaDto)
        {
            var artista = await _ArtistasService.GetArtista(id);

            if (artista == null)
                throw new NotFoundException("No Existe el Registro que Quiere Modificarse");

            _mapper.Map<SaveArtistaDto, Artista>(saveArtistaDto, artista);            

            await _ArtistasService.UpdateArtista(artista);

            var result = _mapper.Map<SaveArtistaDto>(artista);

            var response = new ApiResponse<SaveArtistaDto>(result);
            response.success = true;
            response.Message = "El Registro Ha Sido Actualizado";

            return Ok(response);
        }

        // DELETE: artistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtista(int id)
        {
            var artista = await _ArtistasService.GetArtista(id);

            if (artista == null)
            {
                throw new NotFoundException("El Registo que Quiere Eliminar No Existe");
            }

            await _ArtistasService.DeleteArtista(artista);

            var response = new ApiResponse<string>("Eliminado");
            response.success = true;
            response.Message = "El Registro Ha Sido Eliminado Id: " + id;

            return Ok(response);
        }
    }
}
