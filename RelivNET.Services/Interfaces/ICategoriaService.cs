using RelivNET.Dto.Request;
using RelivNET.Dto.Response;

namespace RelivNET.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<BaseGenericResponse<IEnumerable<CategoriaDtoResponse>>> ListAsync();
        Task<BaseGenericResponse<CategoriaDtoResponse>> FindByIdAsync(int id);
        Task<BaseGenericResponse<int>> AddAsync(CategoriaDtoRequest request);
        Task<BaseResponse> UpdateAsync(int id, CategoriaDtoRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
