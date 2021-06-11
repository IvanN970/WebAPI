using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
namespace WebAPI.Repositories
{
    public interface IEmployeeRepository
    {
        List<EmployeeModel> getEmployees();
        EmployeeModel getEmployee(int id);
        Task<int> Post(EmployeeModel model);
        Task<int> Delete(int id);
        Task<int> Edit(int id, EmployeeModel model);
    }
}
