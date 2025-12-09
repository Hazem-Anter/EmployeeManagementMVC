
namespace WebApp2.DAL.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        bool AddEmployee(Employee employee);
        bool DeleteEmployee(string id);
        bool RehireEmployee(string id);

        bool EditEmployee(Employee employee);

        Employee GetEmployeeById(string id);
        List<Employee> GetEmployees(Expression<Func<Employee,bool>>? filter = null);

        bool ToggleStatus(Employee employee); 

    }
}
