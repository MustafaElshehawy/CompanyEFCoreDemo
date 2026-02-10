
using companySD;
using companySD.Entites;
using Microsoft.EntityFrameworkCore;


using var context = new CompanyDbContext();

context.Database.EnsureCreated();
//InsertData(context);
//ReadEmployees(context);
//ReadEmployeesWithDepartment(context);
UpdateEmployee(context,1);
UpdateEmployee(context,2,"mostafa");
UpdateEmployee(context,3,"mohmmed",20);
UpdateEmployee(context, 4, departmentId: 1);
ReadEmployeesWithDepartment(context);



static void InsertData(CompanyDbContext context)
{
    var DepartmentData = new List<Department>
    {
            new Department { Name = "IT", Location = "Cairo" },
            new Department { Name = "HR", Location = "Mansoura" },
            new Department { Name = "BackEnd", Location = "Mansoura" },
            new Department { Name = "UIUX", Location = "Mansoura" }
    };
    var EmployeeData = new List<Employee>
    {
            new Employee { Name = "Ali", Age = 35, Salary = 28000, DepartmentId = 1 },
            new Employee { Name = "Hassan", Age = 30, Salary = 18000, DepartmentId = 2 },
            new Employee { Name = "Ahmed", Age = 40, Salary = 58000, DepartmentId = 3 },
            new Employee { Name = "Amir", Age = 22, Salary = 15000, DepartmentId = 4 }

    };
    var ProjectData = new List<Project>
    {
            new Project { Title = "Parking App", Budget = 65000 },
            new Project { Title = "RantCar App", Budget = 85000 },
            new Project { Title = "Super Market Cross Platform", Budget = 100000 }
    };
    var EmployeeProjectData = new List<EmployeeProject>
    {
            new EmployeeProject { EmployeeId = 1, ProjectId = 1 },
            new EmployeeProject { EmployeeId = 2, ProjectId = 1 },
            new EmployeeProject { EmployeeId = 3, ProjectId = 1 },
            new EmployeeProject { EmployeeId = 4, ProjectId = 1 },
            new EmployeeProject { EmployeeId = 1, ProjectId = 2 },
            new EmployeeProject { EmployeeId = 1, ProjectId = 3 },
            new EmployeeProject { EmployeeId = 2, ProjectId = 2 }
    };

    context.AddRange(DepartmentData);
    context.SaveChanges();

    context.AddRange(EmployeeData);
    context.SaveChanges();

    context.AddRange(ProjectData);
    context.SaveChanges();

    context.AddRange(EmployeeProjectData);
    context.SaveChanges();
}


static void ReadEmployees(CompanyDbContext context)
{
    var Employee = context.Employees.ToList();

    foreach (var employee in Employee)
    {
        Console.WriteLine($"Name: {employee.Name} Age:{employee.Age} Salary: {employee.Salary} EGP");
    }
}

static void ReadEmployeesWithDepartment(CompanyDbContext context)
{
    var Employees = context.Employees
        .Include(e => e.Department)
        .ToList();
    foreach (var employee in Employees)
    {
        Console.WriteLine($"Name: {employee.Name} Age:{employee.Age} Department: {employee.Department.Name} Location: {employee.Department.Location} Salary: {employee.Salary} EGP");

    }

}

static void UpdateEmployee(CompanyDbContext context,int employeeId,string? name =null, int? age=null, decimal? salary = null, int? departmentId = null)
{
    var Employee = context.Employees.FirstOrDefault(e => e.Id == employeeId);

    if (Employee == null)
    {
        Console.WriteLine("Employee not found");
        return;
    }
    else
    {
        Employee.Name = !string.IsNullOrWhiteSpace(name) ? name: Employee.Name ;
        Employee.Age = age ?? Employee.Age;
        Employee.Salary = salary ?? Employee.Salary;
        Employee.DepartmentId = departmentId ?? Employee.DepartmentId;
        context.SaveChanges();
        Console.WriteLine("Employee update success");
    }

}
