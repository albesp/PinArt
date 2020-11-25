using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PinArt.Core.DTOs;
using PinArt.Core.Entities;
using PinArt.Core.Enumerations;
using PinArt.Core.Interfaces;
using PinArt.Core.DTOs.Security;

namespace PinArt.Api.Controllers
{
    //[Authorize(Roles = nameof(RoleType.Administrator))]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;

        public SecurityController(ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveSecurityDto securityDto)
        {
            var security = _mapper.Map<Security>(securityDto);

            await _securityService.RegisterUser(security);            

            var result = _mapper.Map<SaveSecurityDto>(security);

            return Ok(result);
        }
    }
}
