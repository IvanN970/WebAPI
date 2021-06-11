using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class Employee
    {
        public int Id { set; get;}
        public string Name { set; get;}
        public int Age { set; get; }
        public double Salary { set; get; }
        public int DepartmentId { set; get;}
        public virtual Department Department { set; get;}
    }
}
