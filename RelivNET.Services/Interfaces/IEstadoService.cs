using RelivNET.Dto.Request;
using RelivNET.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelivNET.Services.Interfaces
{
    public interface IEstadoService
    {
        Task<BaseGenericResponse<IEnumerable<EstadoDtoResponse>>> ListAsync();
        Task<BaseGenericResponse<EstadoDtoResponse>> FindByIdAsync(int id);
        Task<BaseGenericResponse<int>> AddAsync(EstadoDtoRequest request);
        Task<BaseResponse> UpdateAsync(int id, EstadoDtoRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
