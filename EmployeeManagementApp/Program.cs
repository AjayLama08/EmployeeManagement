using EmployeeManagementApp.Data;
using Microsoft.EntityFrameworkCore;

var employeeDbContext = new EmployeeDbContext();

ListDepartments(employeeDbContext);
ListEmployees(employeeDbContext);
ListEmpByDept(employeeDbContext);
ListEmpWithAttendances(employeeDbContext);  

//Method to list departments
static void ListDepartments(EmployeeDbContext dbContext)
{
    var departments = dbContext.Departments.ToList();
    Console.WriteLine("Departments list");
   foreach(var dept in departments)
    {
        Console.WriteLine($"{dept.DepartmentCode}: {dept.DepartmentName}");
    }
}

//Method to list all the employees
static void ListEmployees(EmployeeDbContext dbContext)
{
    var employees = dbContext.Employees.ToList();
    Console.WriteLine("\nEmployees list");

    foreach (var emp in employees)
    {
        Console.WriteLine($"{emp.EmployeeId} {emp.EmployeeName}");
    }
}

//Method to list employees by department
static void ListEmpByDept(EmployeeDbContext dbContext)
{
    var empByDept = dbContext.Departments.Include(d => d.Employees).ToList();
    foreach (var dept in empByDept)
    {
        Console.WriteLine($"\nEmployees in {dept.DepartmentName} department");
        foreach (var emp in dept.Employees)
        {
            Console.WriteLine($"{emp.EmployeeId} {emp.EmployeeName}");
        }
    }
}

//Method to list employees with their attendances
static void ListEmpWithAttendances(EmployeeDbContext dbContext)
{
    var empWithAttendances = dbContext.Employees.Include(e => e.Attendances).ToList();
    foreach (var emp in empWithAttendances)
    {
        Console.WriteLine($"\nAttendances of {emp.EmployeeName}");
        foreach (var att in emp.Attendances)
        {
            Console.WriteLine($"{att.AttendanceId} {att.AttendanceDate}");
        }
    }
}

