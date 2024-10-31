using Microsoft.Extensions.Logging;
using RelivNET.Dto.Request;
using RelivNET.Dto.Response;
using RelivNET.Entities;
using RelivNET.Repositories;
using RelivNET.Services.Interfaces;

namespace RelivNET.Services.Implementations
{
    public class CategoriaService : ICategoriaService
    {

        private ICategoriaRepository _categoriaRepository;
        private ILogger<CategoriaService> _logger;

        public CategoriaService(ICategoriaRepository categoriaRepository, ILogger<CategoriaService> logger)
        {
            _categoriaRepository = categoriaRepository;
            _logger = logger;
        }

        public async Task<BaseGenericResponse<int>> AddAsync(CategoriaDtoRequest request)
        {
            var response = new BaseGenericResponse<int>();
            try
            {
                var entity = new Categoria
                {
                    Descripcion = request.Descripcion,
                    FechaCreacion = DateTime.Now,

                };
                var id = await _categoriaRepository.AddAsync(entity);
                response.Data = id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in CategoriaService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al crear la categoria";
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                var categoria = await _categoriaRepository.FindByIdAsync(id);
                if (categoria == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Categoria no encontrada";
                    return response;
                }
                await _categoriaRepository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in CategoriaService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al eliminar la categoria";
            }
            return response;
        }

        public async Task<BaseGenericResponse<CategoriaDtoResponse>> FindByIdAsync(int id)
        {
            var response = new BaseGenericResponse<CategoriaDtoResponse>();
            try
            {
                var categoria = await _categoriaRepository.FindByIdAsync(id);
                if (categoria == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Categoria no encontrada";
                    return response;
                }
                response.Data = new CategoriaDtoResponse
                {
                    Id = categoria.Id,
                    Descripcion = categoria.Descripcion
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in CategoriaService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al obtener la categoria";
            }
            return response;
        }

        public async Task<BaseGenericResponse<IEnumerable<CategoriaDtoResponse>>> ListAsync()
        {
            var response = new BaseGenericResponse<IEnumerable<CategoriaDtoResponse>>();
            try
            {
                var categorias = await _categoriaRepository.ListAsync();
                response.Data = categorias.Select(c => new CategoriaDtoResponse
                {
                    Id = c.Id,
                    Descripcion = c.Descripcion!
                });
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in CategoriaService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al listar categorias";
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, CategoriaDtoRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var categoria = await _categoriaRepository.FindByIdAsync(id);
                if (categoria == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Categoria no encontrada";
                    return response;
                }
                categoria.Descripcion = request.Descripcion;
                categoria.FechaModificacion = DateTime.Now;
                await _categoriaRepository.UpdateAsync(categoria);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in CategoriaService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al actualizar la categoria";
            }
            return response;
        }
    }
}
