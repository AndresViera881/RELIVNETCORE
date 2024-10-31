namespace RelivNET.Dto.Response
{
    public class BaseGenericResponse<T> : BaseResponse
    {
        public T? Data { get; set; }
    }
}
