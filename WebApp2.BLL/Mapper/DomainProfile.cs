
using AutoMapper;
using WebApp2.BLL.ModelVM.Employee;
using WebApp2.DAL.Entity;

namespace WebApp2.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            //          Employee

            // Entity -> GetEmployeeVM (nested → flat)
            CreateMap<Employee, GetEmployeeVM>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));


            CreateMap<AddEmployeeVM, Employee>().ReverseMap();

            CreateMap<EditEmployeeVM, Employee>().ReverseMap();

            CreateMap<GetEmployeeVM, DeleteEmployeeVM>().ReverseMap();


            // GetEmployeeVM -> EditEmployeeVM (flat → flat)
            CreateMap<GetEmployeeVM, EditEmployeeVM>().ReverseMap()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            //////////////////////////////////////////////////////////////////////////////////////
            //          Department

            CreateMap<Department, GetDepartmentVM>().ReverseMap();

        }
    }
}
