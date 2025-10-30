
using WebApp2.BLL.ModelVM.Employee;
using WebApp2.BLL.ModelVM.ResponseResult;

namespace WebApp2.BLL.Service.Abstraction
{
    public interface IEmployeeService
    {
        Response<List<GetEmployeeVM>> GetAllEmployees();
        Response<List<GetEmployeeVM>> GetActiveEmployee();
        Response<List<GetEmployeeVM>> GetNotActiveEmployee();

        Response<EditEmployeeVM> EditEmployee(EditEmployeeVM editedEmployeeVM);  
        Response<bool> DeleteEmployee(DeleteEmployeeVM deleteEmployeeVM);
        Response<bool> RehireEmployee(int id);
        Response<AddEmployeeVM> AddEmployee(AddEmployeeVM addEmployeeVM);

        Response<GetEmployeeVM> GetEmployeeByID(int id);

       


    }
}
