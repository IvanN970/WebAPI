using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
namespace WebAPI.Repositories
{
    public interface IDepartmentRepository
    {
        List<DepartmentModel> getDepartments();
        DepartmentModel getDepartment(int id);
        Task<int> Post(DepartmentModel model);
        Task<int> Delete(int id);
        Task<int> Edit(int id, DepartmentModel model);
    }
}
