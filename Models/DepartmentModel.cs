using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebAPI.Models
{
    public class DepartmentModel
    {
        public int Id { set; get;}
        public string Name { set; get;}
        public virtual ICollection<EmployeeModel> Employees { set; get; }
    }
}
