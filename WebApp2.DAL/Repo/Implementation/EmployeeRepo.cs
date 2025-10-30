
namespace WebApp2.DAL.Repo.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        // connection string
        private readonly WebApp2DbContext dbContext;
        public EmployeeRepo(WebApp2DbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        // Add Employee
        public bool AddEmployee(Employee employee)
        {
            try
            {
                Employee newEmployee = new Employee(employee.Name, employee.Salary
                                                    , employee.Image, employee.DepId, 
                                                    employee.CreatedBy);
                
                if (newEmployee != null)
                {
                    var result = dbContext.Employees.Add(newEmployee);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        // Delete Employee
        public bool DeleteEmployee(int id)
        {
            try
            {
                var result = dbContext.Employees.Where(emp => emp.Id == id).Include(dep => dep.Department).FirstOrDefault();
                
                if (result != null)
                {
                    result.ToggleStatus("hassan");
                    dbContext.SaveChanges();
                    //dbContext.Employees.Remove(result);
                    //dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        // rehire Employee
        public bool RehireEmployee(int id)
        {
            try
            {
                var result = dbContext.Employees.Where(emp => emp.Id == id).Include(dep => dep.Department).FirstOrDefault();

                if (result != null)
                {
                    result.ToggleStatus("hassan");
                    dbContext.SaveChanges();
                    //dbContext.Employees.Remove(result);
                    //dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Edit Employee Date
        public bool EditEmployee(Employee employee)
        {
            try
            {
                var oldEmployee = dbContext.Employees.Where(emp => emp.Id == employee.Id).Include(dep => dep.Department).FirstOrDefault();

                var updateResult = oldEmployee.Update(employee.Name, employee.Salary
                                                       , employee.Image, employee.DepId,
                                                       "hazem");

                if (updateResult)
                {
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Get Employee By Id
        public Employee GetEmployeeById(int id)
        {
            try
            {
                var result = dbContext.Employees.Where(emp => emp.Id == id).Include(dep => dep.Department).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        // Get All Employees
        public List<Employee> GetEmployees(Expression<Func<Employee, bool>>? filter = null)
        {

            try
            {
                if(filter != null)
                {
                    var result = dbContext.Employees.Where(filter).Include(dep => dep.Department).ToList();
                    return result;
                }
                else
                {
                    var result = dbContext.Employees.Include(dep => dep.Department).ToList();
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ToggleStatus(Employee employee)
        {
            try
            {
                var result = dbContext.Employees.Where(emp => emp.Id == employee.Id).Include(dep => dep.Department).FirstOrDefault();

                if (result.Id != null && result.Id > 0)
                {
                    result.ToggleStatus("Ali");
                    dbContext.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
