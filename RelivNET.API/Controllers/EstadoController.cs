using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelivNET.Dto.Request;
using RelivNET.Services.Interfaces;

namespace RelivNET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService _services;
        private readonly ILogger<EstadoController> _logger;

        public EstadoController(IEstadoService services, ILogger<EstadoController> logger)
        {
            _services = services;
            _logger = logger;
        }

        [HttpGet("GetEstados")]
        public async Task<IActionResult> ListAsync()
        {
            var response = await _services.ListAsync();
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost("PostEstados")]
        public async Task<IActionResult> AddAsync([FromBody] EstadoDtoRequest request)
        {
            var response = await _services.AddAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetEstado/{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            var response = await _services.FindByIdAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPut("PutEstado/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EstadoDtoRequest request)
        {
            var response = await _services.UpdateAsync(id, request);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpDelete("DeleteEstado/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _services.DeleteAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
