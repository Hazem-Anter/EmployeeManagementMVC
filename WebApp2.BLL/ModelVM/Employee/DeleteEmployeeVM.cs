
namespace WebApp2.BLL.ModelVM.Employee
{
    public class DeleteEmployeeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int DepId { get; set; }
        public string Department { get; set; }

        public bool IsDeleted {  get; set; } = true;
    }
}
