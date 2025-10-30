
namespace WebApp2.DAL.Entity
{
    public class Employee
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Salary { get; private set; }
        public string? Image {  get; private set; }
        public DateTime CreatedOn {  get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public DateTime? DeletedOn {  get; private set; }
        public string? CreatedBy { get; private set; }
        public string? UpdatedBy { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        [ForeignKey(nameof(Department))]
        public int DepId {  get; private set; }
        public Department Department { get; private set; }

        protected Employee() { }
        public Employee(string name, decimal salary, string image, int depId, string createdBy)
        {
           
                Name = name;
                Salary = salary;
                Image = image;
                CreatedBy = createdBy;
                CreatedOn = DateTime.Now;
                DepId = depId; 
        }

        public bool Update(string name, decimal salary, string image, int depId, string updatedBy)
        {
            if (!string.IsNullOrEmpty(updatedBy))
            {
                Name = name;
                Salary = salary;
                Image = image;
                UpdatedBy = updatedBy;
                UpdatedOn = DateTime.Now;
                DepId = depId;
                return true;
            }
            return false;
        }

        public bool ToggleStatus(string deletedBy)
        {
            if (!string.IsNullOrEmpty(deletedBy))
            {
                DeletedBy = deletedBy;
                IsDeleted = !IsDeleted;
                DeletedOn = DateTime.Now;
                return true;
            }
            return false;
        }
    }
}
