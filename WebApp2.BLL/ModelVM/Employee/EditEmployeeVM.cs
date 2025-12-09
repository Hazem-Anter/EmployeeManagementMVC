
namespace WebApp2.BLL.ModelVM.Employee
{
    public class EditEmployeeVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int DepId { get; set; }
        public string Department { get; set; }

        // this is the stored image path in DB
        public string? Image { get; set; }

        // this is for uploading a new image
        public IFormFile? ImageUpload { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
