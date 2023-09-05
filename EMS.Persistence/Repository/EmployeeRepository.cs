using EMS.Application.DTOs.Employee;
using EMS.Application.Interface.Repository;
using EMS.Domain.Entities;
using EMS.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EMS.Persistence.Repository
{
    public class EmployeeRepository : RepositoryAsync, IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
       
        public async Task<List<EmployeeDto>> GetEmployeeDtos()
        {
            return await _dbContext.Employees.Select(x => new EmployeeDto
            {
                Firstname = x.Firstname,
                Surname = x.Surname,
                DepartmentId = x.DepartmentId
            }).ToListAsync();
        }

        public  List<Employee>  GetlAllEmployee()
        {
            return _dbContext.Employees.ToList();   
        }

        public Employee GetById(Guid id)
        {
            return _dbContext.Employees.Where(s => s.Id == id).FirstOrDefault();
        }
        
        public Employee GetByDepartmentId(Guid departmentId)
        {
            return _dbContext.Employees.Where(s => s.DepartmentId == departmentId).FirstOrDefault();
        }

        public Employee GetByIdOrDepartmentId(Guid id, Guid departmentId)
        {
            return _dbContext.Employees.Where(s => s.Id == id || s.DepartmentId == departmentId).
                FirstOrDefault();
        }

        public async Task<EmployeeDto?> LoadEmployeeDetailAsync(Guid id) =>
            await _dbContext.Employees
              .Where(x => x.Id == id)
            .Select(x => new EmployeeDto
            {
                DepartmentId = x.DepartmentId,
                Surname = x.Surname,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Gender = x.Gender,
                Salary = x.Salary,
                IsActive = x.IsActive
            })
             .FirstOrDefaultAsync();

    }
}
