using EMS.Application.DTOs.Employee;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Interface.Repository
{
    public interface IEmployeeRepository : IRepository
    {
        List<Employee> GetlAllEmployee();
        Employee GetById(Guid id);
        Employee GetByDepartmentId(Guid departmentId);
        Employee GetByIdOrDepartmentId(Guid id, Guid departmentId);
        Task<List<EmployeeDto>> GetEmployeeDtos();
        Task<EmployeeDto> LoadEmployeeDetailAsync(Guid id);
    }
}
