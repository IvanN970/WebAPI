using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
namespace WebAPI.Repositories
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private AppDBContext context;
        public DepartmentRepository(AppDBContext context)
        {
            this.context = context;
        }
        public List<DepartmentModel> getDepartments()
        {
            var result = context.Department.Select(x => new DepartmentModel
            {
                Id=x.Id,
                Name=x.Name,
            }).ToList();
            return result;
        }
        public DepartmentModel getDepartment(int id)
        {
            var result = context.Department.Where(x=>x.Id==id).Select(x => new DepartmentModel
            {
                Id=x.Id,
                Name=x.Name
            }).FirstOrDefault();
            return result;
        }
        public async Task<int> Post(DepartmentModel model)
        {
            Department department = new Department();
            department.Name = model.Name;
            await context.Department.AddAsync(department);
            await context.SaveChangesAsync();
            return 1;
        }
        public async Task<int> Delete(int id)
        {
            var result = context.Department.FirstOrDefault(x => x.Id == id);
            if(result!=null)
            {
                context.Remove(result);
                await context.SaveChangesAsync();
                return 1;
            }
            return -1;
        }
        public async Task<int> Edit(int id,DepartmentModel model)
        {
            var result = context.Department.FirstOrDefault(x => x.Id == id);
            if(result!=null)
            {
                result.Name = model.Name;
                await context.SaveChangesAsync();
                return 1;
            }
            return -1;
        }
    }
}
