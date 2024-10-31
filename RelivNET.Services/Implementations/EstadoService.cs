using Microsoft.Extensions.Logging;
using RelivNET.Dto.Request;
using RelivNET.Dto.Response;
using RelivNET.Entities;
using RelivNET.Repositories;
using RelivNET.Services.Interfaces;

namespace RelivNET.Services.Implementations
{
    public class EstadoService : IEstadoService
    {

        private readonly IEstadoRepository _estadoRepository;
        private readonly ILogger<EstadoService> _logger;

        public EstadoService(IEstadoRepository estadoRepository, ILogger<EstadoService> logger)
        {
            _estadoRepository = estadoRepository;
            _logger = logger;
        }

        public async Task<BaseGenericResponse<int>> AddAsync(EstadoDtoRequest request)
        {
            var response = new BaseGenericResponse<int>();
            try
            {
                var entity = new Estado
                {
                    Descripcion = request.Descripcion,
                    FechaCreacion = DateTime.Now,

                };
                var id = await _estadoRepository.AddAsync(entity);
                response.Data = id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in EstadoService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al crear el estado";
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();
            try
            {
                var estado = await _estadoRepository.FindByIdAsync(id);
                if (estado == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Estado no encontrado";
                    return response;
                }
                await _estadoRepository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in EstadoService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al eliminar el estado";
            }
            return response;
        }

        public async Task<BaseGenericResponse<EstadoDtoResponse>> FindByIdAsync(int id)
        {
            var response = new BaseGenericResponse<EstadoDtoResponse>();
            try
            {
                var estado = await _estadoRepository.FindByIdAsync(id);
                if (estado == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Estado no encontrado";
                    return response;
                }
                response.Data = new EstadoDtoResponse
                {
                    Id = estado.Id,
                    Descripcion = estado.Descripcion
                };
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in EstadoService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al obtener el estado";
            }
            return response;
        }

        public async Task<BaseGenericResponse<IEnumerable<EstadoDtoResponse>>> ListAsync()
        {
            var response = new BaseGenericResponse<IEnumerable<EstadoDtoResponse>>();
            try
            {
                var estados = await _estadoRepository.ListAsync();
                response.Data = estados.Select(c => new EstadoDtoResponse
                {
                    Id = c.Id,
                    Descripcion = c.Descripcion!
                });
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in EstadoService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al listar los estados";
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, EstadoDtoRequest request)
        {
            var response = new BaseResponse();
            try
            {
                var estado = await _estadoRepository.FindByIdAsync(id);
                if (estado == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Estado no encontrado";
                    return response;
                }
                estado.Descripcion = request.Descripcion;
                estado.FechaModificacion = DateTime.Now;
                await _estadoRepository.UpdateAsync(estado);
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Error in EstadoService. {message}", ex.Message);
                response.Success = false;
                response.ErrorMessage = "ocurrio un error al actualizar el estado";
            }
            return response;
        }
    }
}
