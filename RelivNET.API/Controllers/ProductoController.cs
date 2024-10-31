using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelivNET.Dto.Request;
using RelivNET.Services.Interfaces;

namespace RelivNET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _services;
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(IProductoService services, ILogger<ProductoController> logger)
        {
            _services = services;
            _logger = logger;
        }

        [HttpGet("GetProductos")]
        public async Task<IActionResult> ListAsync()
        {
            var response = await _services.ListAsync();
            return response.Success ? Ok(response) : NotFound(response);
        }


        [HttpPost("PostProducto")]
        public async Task<IActionResult> AddAsync([FromBody] ProductoDtoRequest request)
        {
            var response = await _services.AddAsync(request);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("GetProducto/{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            var response = await _services.FindByIdAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPut("PutProducto/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductoDtoRequest request)
        {
            var response = await _services.UpdateAsync(id, request);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpDelete("DeleteProducto/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _services.DeleteAsync(id);
            return response.Success ? Ok(response) : NotFound(response);
        }
    }
}
