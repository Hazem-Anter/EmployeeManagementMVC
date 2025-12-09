
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp2.BLL.Helper;
using WebApp2.BLL.ModelVM.Employee;
using WebApp2.BLL.ModelVM.ResponseResult;
using WebApp2.DAL.Entity;
using WebApp2.DAL.Repo.Abstraction;
using WebApp2.DAL.Repo.Implementation;

namespace WebApp2.BLL.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;

        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            this.employeeRepo = employeeRepo;    
            this._mapper = mapper;  
        }

        /*
                // Edit Employee     
        */
        public Response<EditEmployeeVM> EditEmployee(EditEmployeeVM editedEmployeeVM)
        {
            try
            {
                if (editedEmployeeVM.ImageUpload != null)
                {
                    editedEmployeeVM.Image = Upload.UploadFile("Files", editedEmployeeVM.ImageUpload);
                }

                var mappedEditedEmplyee = _mapper.Map<Employee>(editedEmployeeVM);

                var newEmployee = employeeRepo.EditEmployee(mappedEditedEmplyee);

                
                return new Response<EditEmployeeVM>(editedEmployeeVM, null, false);
            }
            catch (Exception ex)
            {

                return new Response<EditEmployeeVM>(null, ex.Message, true);
            }
           
        }

        /*
                // Delete Employee     
        */
        public Response<bool> DeleteEmployee(DeleteEmployeeVM deleteEmployeeVM)
        {
            try
            {
                var employee = employeeRepo.DeleteEmployee(deleteEmployeeVM.Id);

                return new Response<bool>(true, null, false);
            }
            catch (Exception ex)
            {

                return new Response<bool>(false, ex.Message, true);
            }
        }

        /*
                // Rehire Employee     
        */
        public Response<bool> RehireEmployee(string id)
        {
            try
            {
                var employee = employeeRepo.RehireEmployee(id);

                return new Response<bool>(true, null, false);
            }
            catch (Exception ex)
            {

                return new Response<bool>(false, ex.Message, true);
            }
        }

        /*
                // Add Employee     
        */
        public Response<AddEmployeeVM> AddEmployee(AddEmployeeVM addEmployeeVM)
        {
            try
            {
                var Image = Upload.UploadFile("Files", addEmployeeVM.ImageUpload);
                addEmployeeVM.Image = Image;

                //Employee mappedEmployee = new Employee(addEmployeeVM.Name, addEmployeeVM.Salary
                //                                     , addEmployeeVM.ImageFile, addEmployeeVM.DepId, 
                //                                        addEmployeeVM.CreatedBy);

                var mappedEmployee = _mapper.Map<Employee>(addEmployeeVM);

                var employee = employeeRepo.AddEmployee(mappedEmployee);

                return new Response<AddEmployeeVM>(addEmployeeVM, null, false);

            }
            catch (Exception ex)
            {

                return new Response<AddEmployeeVM>(null, ex.Message, true);
            }
            
        }

        /*
                // Get All Employees     
        */
        public Response<List<GetEmployeeVM>> GetAllEmployees()
        {
            try
            {
                var result = employeeRepo.GetEmployees();
                //List<GetEmployeeVM> mappedEmployee = new List<GetEmployeeVM>();
                //foreach (var item in result)
                //{
                //    mappedEmployee.Add(new GetEmployeeVM()
                //    {
                //        Id = item.Id,
                //        Name = item.Name,
                //        Salary = item.Salary,
                //        DepId = item.DepId,
                //        Department = item.Department.Name,
                //        ImageFile = item.Image,
                //        IsDeleted = (bool)item.IsDeleted
                //    });
                //}

                var mappedEmployee = _mapper.Map<List<GetEmployeeVM>>(result);

                return new Response<List<GetEmployeeVM>>(mappedEmployee, null, false);
            }
            catch (Exception ex)
            {

                return new Response<List<GetEmployeeVM>>(null, ex.Message, true);
            }
        }

        /*
                // Get Active Employees     
        */
        public Response<List<GetEmployeeVM>> GetActiveEmployee()
        {
            try
            {
                var result = employeeRepo.GetEmployees(emp => emp.IsDeleted == false);
                //List<GetEmployeeVM> mappedEmployee = new List<GetEmployeeVM>();
                //foreach (var item in result)
                //{
                //    mappedEmployee.Add(new GetEmployeeVM()
                //    {
                //        Id = item.Id,
                //        Name = item.Name,
                //        Salary = item.Salary,
                //        DepId = item.DepId,
                //        Department = item.Department.Name,
                //        ImageFile = item.Image,
                //        IsDeleted = (bool)item.IsDeleted
                //    });
                //}

                var mappedEmployee = _mapper.Map<List<GetEmployeeVM>>(result);

                return new Response<List<GetEmployeeVM>>(mappedEmployee, null, false);
            }
            catch (Exception ex)
            {

                return new Response<List<GetEmployeeVM>>(null, ex.Message, true);
            }
        }

        /*
                // Get not Active Employees     
        */
        public Response<List<GetEmployeeVM>> GetNotActiveEmployee()
        {
            try
            {
                var result = employeeRepo.GetEmployees(emp => emp.IsDeleted == true);
                //List<GetEmployeeVM> mappedEmployee = new List<GetEmployeeVM>();
                //foreach (var item in result)
                //{
                //    mappedEmployee.Add(new GetEmployeeVM()
                //    {
                //        Id = item.Id,
                //        Name = item.Name,
                //        Salary = item.Salary,
                //        DepId = item.DepId,
                //        Department = item.Department.Name,
                //        ImageFile = item.Image,
                //        IsDeleted = (bool)item.IsDeleted
                //    });
                //}

                var mappedEmployee = _mapper.Map<List<GetEmployeeVM>>(result);

                return new Response<List<GetEmployeeVM>>(mappedEmployee, null, false);
            }
            catch (Exception ex)
            {

                return new Response<List<GetEmployeeVM>>(null, ex.Message, true);
            }
        }

        /*
                // Get employee By ID     
        */
        public Response<GetEmployeeVM> GetEmployeeByID(string id)
        {
            try
            {
                var employee = employeeRepo.GetEmployeeById(id);

                //GetEmployeeVM mappedEmployee = new GetEmployeeVM()
                //{
                //    Id = employee.Id,
                //    Name = employee.Name,
                //    Salary = employee.Salary,
                //    DepId = employee.DepId,
                //    Department = employee.Department.Name,
                //    ImageFile = employee.Image,
                //    IsDeleted = (bool)employee.IsDeleted

                //};

                var mappedEmployee = _mapper.Map<GetEmployeeVM>(employee);

                return new Response<GetEmployeeVM>(mappedEmployee, null, false);

            }
            catch (Exception ex)
            {
                return new Response<GetEmployeeVM>(null, ex.Message, true);
            }
        }

        
    }
}
