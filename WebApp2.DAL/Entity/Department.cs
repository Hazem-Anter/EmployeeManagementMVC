
namespace WebApp2.DAL.Entity
{
    public class Department
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Area { get; private set; }

        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? CreatedBy { get; private set; }
        public string? UpdatedBy { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool IsDeleted { get; private set; } = false;

        public List<Employee> Employees { get; set; }

        protected Department(){}

        public Department(string name, string area, string createdBy)
        {
            Name = name;
            Area = area;
            CreatedBy = createdBy;
            CreatedOn = DateTime.Now;
        }

        public bool Update(string name, string area, string updatedBy)
        {
            if (!updatedBy.IsNullOrEmpty())
            {
                Name = name;
                Area = area;
                UpdatedBy = updatedBy;
                UpdatedOn = DateTime.Now;
                return true;
            }
            return false;
        }

        public bool ToggleStatus(string deletedBy)
        {
            if (!deletedBy.IsNullOrEmpty())
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
