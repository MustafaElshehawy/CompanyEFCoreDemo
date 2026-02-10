using System;
using System.Collections.Generic;
using System.Text;

namespace companySD.Entites
{
    public class EmployeeProject
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public Project project { get; set; }
        public int ProjectId { get; set; }

        public DateTime JoinDate { get; set; } = DateTime.Now;
    }
}
