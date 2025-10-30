
namespace WebApp2.BLL.ModelVM.ResponseResult
{
    public record class Response<T>(T result, string errorMessage, bool HasError);
   
}
