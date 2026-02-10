
using System;
using System.Collections.Generic;
using System.Text;

namespace companySD.Entites
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }


        public ICollection<EmployeeProject> EmployeeProjects { get; set; }= new List<EmployeeProject>();

    }
}
