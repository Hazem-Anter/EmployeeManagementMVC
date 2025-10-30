using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApp2.BLL.ModelVM.Employee;
using WebApp2.BLL.Service.Abstraction;

namespace WebApp2.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;

        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService, IMapper mapper)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
            this._mapper = mapper;
        }

        /*
                // Get All Employees     
        */

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = employeeService.GetAllEmployees();
            return View(employees);
        }

        /*
                // Get Active Employees     
        */

        [HttpGet]
        public IActionResult GetActiveEmployees()
        {
            var employees = employeeService.GetActiveEmployee();
            return View(employees);
        }

        /*
                // Get Not Active Employees     
        */

        [HttpGet]
        public IActionResult GetNotActiveEmployees()
        {
            var employees = employeeService.GetNotActiveEmployee();
            return View(employees);
        }

        /*
                // Get Employee By ID     
        */
        [HttpGet]
        public IActionResult GetEmployeeById(int id) 
        {
            var employee = employeeService.GetEmployeeByID(id);
            return View("GetEmployeeById", employee);
        }

        /*
                // view/Get Employee By Id To Edit his/her Data     
        */
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employeeService.GetEmployeeByID(id);
            /*//EditEmployeeVM editedMappedEmployee = new EditEmployeeVM()
            //{
            //    Id = id,
            //    Name = employee.result.Name,
            //    Salary = employee.result.Salary,
            //    DepId = employee.result.DepId,
            //    Department = employee.result.Department,
            //    ImageFile = employee.result.ImageFile // string path from DB

            //};*/

            var editedMappedEmployee = _mapper.Map<EditEmployeeVM>(employee.result);

            //var departments = departmentService.GetDepartments();
            //ViewBag.departments = departments;

            return View("Edit", editedMappedEmployee);
        }
        /*
                // Edit Employee Data and redirect to Get All Employees Action      
        */
        [HttpPost]
        public IActionResult Edit(EditEmployeeVM editEmployeeVM)
        {

            /*if (ModelState.IsValid)
            {
                var employee = employeeService.EditEmployee(editEmployeeVM);
                if (!employee.HasError)
                {
                    return RedirectToAction("Action", "Employee");
                }
            }
            var departments = departmentService.GetDepartments();
            ViewBag.departments = departments;
            return View("Edit");*/

            var employee = employeeService.EditEmployee(editEmployeeVM);
            return RedirectToAction("Action", "Employee");

        }

        /*
                // view/Get Employee By Id To delete Employee      
        */
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = employeeService.GetEmployeeByID(id);
            /*//DeleteEmployeeVM deletedMappedEmployee = new DeleteEmployeeVM()
            //{
            //    Id = id,
            //    Name = employee.result.Name,
            //    Salary = employee.result.Salary,
            //    DepId = employee.result.DepId,
            //    Department = employee.result.Department
            //};*/

            var deletedMappedEmployee = _mapper.Map<DeleteEmployeeVM>(employee.result);

            return View("Delete", deletedMappedEmployee);
        }

        /*
                // Delete Employee and redirect to Get All Employees Action      
        */
        [HttpPost]
        public IActionResult Delete(DeleteEmployeeVM deleteEmployeeVM)
        {
            var employee = employeeService.DeleteEmployee(deleteEmployeeVM);
            return RedirectToAction("Action", "Employee");
        }

        /*
                // view Empty Form for the Addition       
        */
        [HttpGet]
        public IActionResult Add()
        {
            //var departments = departmentService.GetDepartments();
            //ViewBag.departments = departments;
            /*//if (departments.HasError)
            //{
            //    return View("Error", "Employee");
            //}*/
            return View("Add");
        }

        /*
                // Add Employee and redirect to Get All Employees Action      
        */
        [HttpPost]
        public IActionResult Add(AddEmployeeVM addEmployeeVM)
        {

            /*//if (ModelState.IsValid)
            //{
            //    var employee = employeeService.AddEmployee(addEmployeeVM);
            //    if (!employee.HasError)
            //    {
            //        return RedirectToAction("GetEmployees", "Employee");
            //    }
            //}
            //var departments = departmentService.GetDepartments();
            //ViewBag.departments = departments;
            //return View(addEmployeeVM);*/
            var employee = employeeService.AddEmployee(addEmployeeVM);
            return RedirectToAction("GetEmployees", "Employee");
        }

        [HttpGet]
        public IActionResult Action()
        {
            var employees = employeeService.GetAllEmployees();
            return View(employees);
        }

        /*
                // Rehire an Employee (Set IsDeleted = false)
        */
        [HttpPost]
        public IActionResult Rehire(int id)
        {
            var result = employeeService.RehireEmployee(id);

            
            return RedirectToAction("GetEmployees", "Employee");
        }


    }
}
