

using AutoMapper;
using WebApp2.DAL.Repo.Abstraction;

namespace WebApp2.BLL.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo departmentRepo;
        private readonly IMapper mapper;
        public DepartmentService(IDepartmentRepo departmentRepo, IMapper mapper) 
        {
            this.departmentRepo = departmentRepo;
            this.mapper = mapper;
        }
        public Response<List<GetDepartmentVM>> GetDepartments()
        {
            try
            {
                var result = departmentRepo.GetDepartments();

                //List<GetDepartmentVM> mappedDepartment = new List<GetDepartmentVM>();
                //foreach (var item in result)
                //{
                //    mappedDepartment.Add(
                //        new GetDepartmentVM 
                //        { 
                //            Id = item.Id, 
                //            Name = item.Name 
                //        } 
                //        );                    
                //}

                var mappedDepartment = mapper.Map<List<GetDepartmentVM>>(result); 

                return new Response<List<GetDepartmentVM>>(mappedDepartment, null, false);
                
            }
            catch (Exception ex)
            {
                return new Response<List<GetDepartmentVM>>(null, ex.Message, true);
            }
        }
    }
}
