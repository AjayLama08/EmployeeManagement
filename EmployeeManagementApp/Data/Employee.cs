using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Data
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        
        [MaxLength(50)]
        public required string EmployeeName { get; set; }
        [MaxLength(50)]
        public string? Position { get; set; }

        public required string DepartmentCode { get; set; }

        public Department? Department { get; set; }

        public List<Attendance>? Attendances { get; set; }
    }
}
