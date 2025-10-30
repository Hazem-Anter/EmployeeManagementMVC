
using System.Linq;
using System.Linq.Expressions;
using WebApp2.DAL.Database;
using WebApp2.DAL.Entity;
using static System.Net.Mime.MediaTypeNames;

namespace WebApp2.DAL.Repo.Implementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly WebApp2DbContext dbContext;
        public DepartmentRepo(WebApp2DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // Add Department
        public bool AddDepartment(string name, string area, string createdBy)
        {
            try
            {
                Department newDepartment = new Department(name, area, createdBy);

                if (newDepartment != null)
                {
                    var result = dbContext.Departments.Add(newDepartment);
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

        // Delete Department
        public bool DeleteDepartment(int id)
        {
            try
            {
                var result = dbContext.Departments.Where(d => d.Id == id).FirstOrDefault();

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
        // Edit Department Date
        public bool EditDepartment(int id, string name, string area, string updatedBy)
        {
            try
            {
                var oldDepartment = dbContext.Departments.Where(d => d.Id == id).FirstOrDefault();

                var updateResult = oldDepartment.Update(name, area, updatedBy);

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

        // Get Department By Id
        public Department GetDepartmentById(int id)
        {
            try
            {
                var result = dbContext.Departments.Where(d => d.Id == id).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Get All Departments
        public List<Department> GetDepartments(Expression<Func<Department, bool>>? filter = null)
        {
            try
            {
                if (filter != null)
                {
                    var result = dbContext.Departments.Where(filter).ToList();
                    return result;
                }
                else
                {
                    var result = dbContext.Departments.ToList();
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool ToggleStatus(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
