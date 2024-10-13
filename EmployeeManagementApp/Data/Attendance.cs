using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Data
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public int EmployeeId { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime AttendanceDate { get; set; }

        public Employee? Employee { get; set; }
    }
}
