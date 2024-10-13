using Microsoft.EntityFrameworkCore;    

namespace EmployeeManagementApp.Data
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        private string DbPath { get; set; } = string.Empty;

        public EmployeeDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Employee.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source = {DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentCode)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Employee>()
                .HasMany(e => e.Attendances)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Department>().HasData(
            new Department { DepartmentCode = "HR", DepartmentName = "Human Resources" },
            new Department { DepartmentCode = "IT", DepartmentName = "Information Technology" },
            new Department { DepartmentCode = "FN", DepartmentName = "Finance" },
            new Department { DepartmentCode = "MK", DepartmentName = "Marketing" }
);
            builder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, EmployeeName = "John Doe", Position = "Manager", DepartmentCode = "HR" },
            new Employee { EmployeeId = 2, EmployeeName = "Jane Smith", Position = "Software Developer", DepartmentCode = "IT" },
            new Employee { EmployeeId = 3, EmployeeName = "Samuel Lee", Position = "Accountant", DepartmentCode = "FN" },
            new Employee { EmployeeId = 4, EmployeeName = "Emma Brown", Position = "Marketing Specialist", DepartmentCode = "MK" }
);
            builder.Entity<Attendance>().HasData(
            new Attendance { AttendanceId = 1, EmployeeId = 1, AttendanceDate = new DateTime(2024, 10, 1) },
            new Attendance { AttendanceId = 2, EmployeeId = 1, AttendanceDate = new DateTime(2024, 10, 2) },
            new Attendance { AttendanceId = 3, EmployeeId = 2, AttendanceDate = new DateTime(2024, 10, 1) },
            new Attendance { AttendanceId = 4, EmployeeId = 2, AttendanceDate = new DateTime(2024, 10, 3) },
            new Attendance { AttendanceId = 5, EmployeeId = 3, AttendanceDate = new DateTime(2024, 10, 1) },
            new Attendance { AttendanceId = 6, EmployeeId = 3, AttendanceDate = new DateTime(2024, 10, 2) },
            new Attendance { AttendanceId = 7, EmployeeId = 4, AttendanceDate = new DateTime(2024, 10, 3) },
            new Attendance { AttendanceId = 8, EmployeeId = 4, AttendanceDate = new DateTime(2024, 10, 4) }
);




        }
    }
}
