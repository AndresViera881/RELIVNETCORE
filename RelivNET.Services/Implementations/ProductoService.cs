using Microsoft.Extensions.Logging;
using RelivNET.Dto.Request;
using RelivNET.Dto.Response;
using RelivNET.Entities;
using RelivNET.Repositories;
using RelivNET.Services.Interfaces;

namespace RelivNET.Services.Implementations
{
    public class ProductoService : IProductoService
    {

        private readonly IProductoRepository _productoRepository;
        private readonly ILogger<ProductoService> _logger;

        public ProductoService(IProductoRepository productoRepository, ILogger<ProductoService> logger)
        {
            _productoRepository = productoRepository;
            _logger = logger;
        }

        public async Task<BaseGenericResponse<int>> AddAsync(ProductoDtoRequest request)
        {
            var response = new BaseGenericResponse<int>();
            try
            {
                var entity = new Producto
                {
                    Nombre = request.Nombre,
                    Precio = request.Precio,
                    Stock = request.Stock,
                    CategoriaId = request.CategoriaId,
                    EstadoId = request.EstadoId,
                    FechaCreacion = Convert.ToDateTime($"{request.FechaCreacion}"),

                };

                var id = await _productoRepository.AddAsync(entity);
                response.Data = id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al crear el producto";
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                var producto = await _productoRepository.FindByIdAsync(id);
                if (producto == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Producto no encontrado";
                    return response;
                }
                await _productoRepository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in ProductoService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al eliminar el producto";
            }
            return response;
        }

        public async Task<BaseGenericResponse<ProductoDtoResponse>> FindByIdAsync(int id)
        {
            var response = new BaseGenericResponse<ProductoDtoResponse>();
            try
            {
                var producto = await _productoRepository.FindByIdAsync(id);
                if (producto == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Producto no encontrado";
                    return response;
                }
                response.Data = new ProductoDtoResponse
                {
                    Id = producto.Id,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    Categoria = producto.Categoria.Descripcion,
                    Estado = producto.Estado.Descripcion,
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in ProductoService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al obtener el producto";
            }
            return response;
        }

        public async Task<BaseGenericResponse<ICollection<ProductoDtoResponse>>> ListAsync()
        {
            var response = new BaseGenericResponse<ICollection<ProductoDtoResponse>>();
            try
            {
                var productos = await _productoRepository.ListAsync();
                response.Data = productos.Select(c => new ProductoDtoResponse
                {
                    Id = c.Id,
                    Nombre = c.Nombre!,
                    Precio = c.Precio,
                    Stock = c.Stock,
                    Categoria = c.Categoria.Descripcion,
                    Estado = c.Estado.Descripcion,
                }).ToList();

                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in ProductoService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al listar los productos";
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, ProductoDtoRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var producto = await _productoRepository.FindByIdAsync(id);
                if (producto == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Producto no encontrado";
                    return response;
                }

                producto.Nombre = request.Nombre;
                producto.Precio = request.Precio;
                producto.Stock = request.Stock;
                producto.CategoriaId = request.CategoriaId;
                producto.EstadoId = request.EstadoId;
                
                await _productoRepository.UpdateAsync(producto);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in ProductoService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al actualizar el producto";
            }
            return response;
        }
    }
}
