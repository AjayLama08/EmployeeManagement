using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Data
{
    public class Department
    {
        [Key]
        [MaxLength(10)]
        public required string DepartmentCode { get; set; }

        public required string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
