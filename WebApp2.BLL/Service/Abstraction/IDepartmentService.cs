
namespace WebApp2.BLL.Service.Abstraction
{
    public interface IDepartmentService
    {
        Response<List<GetDepartmentVM>> GetDepartments();
    }
}
