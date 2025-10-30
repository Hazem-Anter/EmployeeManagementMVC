
namespace WebApp2.DAL.Repo.Abstraction
{
    public interface IDepartmentRepo
    {

        bool AddDepartment(string name, string area ,string createdBy);
        bool DeleteDepartment(int id);

        bool EditDepartment(int id, string name, string area, string updatedBy);

        Department GetDepartmentById(int id);
        List<Department> GetDepartments(Expression<Func<Department, bool>>? filter = null);

        bool ToggleStatus(Department department);
    }
}
