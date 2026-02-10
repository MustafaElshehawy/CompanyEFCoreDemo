using System;
using System.Collections.Generic;
using System.Text;

namespace companySD.Entites
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Budget { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
