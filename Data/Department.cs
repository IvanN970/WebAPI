using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebAPI.Data
{
    public class Department
    {
        public int Id { set; get;}
        public string Name { set; get;}
        public virtual ICollection<Employee> Employees { set; get;}
    }
}
