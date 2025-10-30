
namespace WebApp2.DAL.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        bool AddEmployee(Employee employee);
        bool DeleteEmployee(int id);
        bool RehireEmployee(int id);

        bool EditEmployee(Employee employee);

        Employee GetEmployeeById(int id);
        List<Employee> GetEmployees(Expression<Func<Employee,bool>>? filter = null);

        bool ToggleStatus(Employee employee); 

    }
}
