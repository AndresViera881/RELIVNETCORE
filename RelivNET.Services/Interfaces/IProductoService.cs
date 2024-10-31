using RelivNET.Dto.Request;
using RelivNET.Dto.Response;

namespace RelivNET.Services.Interfaces
{
    public interface IProductoService
    {
        Task<BaseGenericResponse<ICollection<ProductoDtoResponse>>> ListAsync();
        Task<BaseGenericResponse<ProductoDtoResponse>> FindByIdAsync(int id);
        Task<BaseGenericResponse<int>> AddAsync(ProductoDtoRequest request);
        Task<BaseResponse> UpdateAsync(int id, ProductoDtoRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
