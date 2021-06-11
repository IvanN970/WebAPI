using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;
namespace WebAPI.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private AppDBContext context;
        public EmployeeRepository(AppDBContext context)
        {
            this.context = context;
        }
        public List<EmployeeModel> getEmployees()
        {
            var result = context.Employee.Select(x => new EmployeeModel
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                Salary = x.Salary,
                DepartmentId = x.DepartmentId,
                Department=new DepartmentModel
                {
                    Id=x.Department.Id,
                    Name=x.Department.Name
                }
            }).ToList();

            return result;
        }
        public EmployeeModel getEmployee(int id)
        {
            var result = context.Employee.Where(x => x.Id == id).Select(x => new EmployeeModel
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                Salary = x.Salary,
                DepartmentId = x.DepartmentId,
                Department = new DepartmentModel
                {
                    Id = x.Department.Id,
                    Name = x.Department.Name
                }
            }).FirstOrDefault();
            return result;
        }
        public async Task<int> Post(EmployeeModel model)
        {
            Employee employee = new Employee();
            employee.Name = model.Name;
            employee.Age = model.Age;
            employee.Salary = model.Salary;
            employee.DepartmentId = model.DepartmentId;
            await context.Employee.AddAsync(employee);
            await context.SaveChangesAsync();
            return 1;
        }
        public async Task<int> Delete(int id)
        {
            var result = context.Employee.FirstOrDefault(x => x.Id == id);
            if(result!=null)
            {
               context.Remove(result);
               await context.SaveChangesAsync();
               return 1;
            }
            return -1;
        }
        public async Task<int> Edit(int id,EmployeeModel model)
        {
            var result = context.Employee.FirstOrDefault(x => x.Id == id);
            if(result!=null)
            {
                result.Name = model.Name;
                result.Age = model.Age;
                result.Salary = model.Salary;
                result.DepartmentId = model.DepartmentId;
                await context.SaveChangesAsync();
                return 1;
            }
            return -1;
        }
    }
}
