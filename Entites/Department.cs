using System;
using System.Collections.Generic;
using System.Text;

namespace companySD.Entites
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Employee> Employees { get; set; }= new List<Employee>();
    }
}
