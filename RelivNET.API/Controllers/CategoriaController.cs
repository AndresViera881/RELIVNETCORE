using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelivNET.Dto.Request;
using RelivNET.Services.Interfaces;

namespace RelivNET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _services;
        private readonly ILogger<CategoriaController> _logger;

        public CategoriaController(ICategoriaService services, ILogger<CategoriaController> logger)
        {
            _services = services;
            _logger = logger;
        }

        [HttpGet("GetCategorias")]
        public async Task<IActionResult> ListAsync()
        {
            var response = await _services.ListAsync();
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost("PostCategoria")]
        public async Task<IActionResult> AddAsync([FromBody] CategoriaDtoRequest request)
        {
            var response = await _services.AddAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetCategoria/{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            var response = await _services.FindByIdAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPut("PutCategoria/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoriaDtoRequest request)
        {
            var response = await _services.UpdateAsync(id, request);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpDelete("DeleteCategoria/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _services.DeleteAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
