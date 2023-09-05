using EMS.Application.DTOs.Employee;
using EMS.Application.Interface.Repository;
using EMS.Application.Interface.Service;
using EMS.Domain.Entities;

namespace EMS.Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }
        public async Task<CreateEmployeeRequestModel> Create(EmployeeDto request)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = new Guid(),
                    Surname = request.Surname,
                    Firstname = request.Firstname,
                    Lastname = request.Lastname,
                    Gender = request.Gender,
                    Salary = request.Salary,
                    IsActive = request.IsActive,
                    DepartmentId = request.DepartmentId,
                };

                var findEmployee = _employeeRepository.GetById(employee.Id);

                if (findEmployee == null)
                {
                    _employeeRepository.CreateAsync(employee);
                }
                else
                {
                    return new CreateEmployeeRequestModel(false,
                                                          "",
                                                          "No such employee exist..");
                }

            }
            catch (Exception)
            {
                return new CreateEmployeeRequestModel(false,
                                             "",
                                             "Something Went wrong..");
            }
                
            return new CreateEmployeeRequestModel(true,
                                              "",
                                              "Employee Record successfully created..");


        }



        public async Task<CreateEmployeeRequestModel> Delete(Guid id)
        {

            var deleteEmployee = _employeeRepository.GetById(id);

            if (deleteEmployee == null)
            {
                return new CreateEmployeeRequestModel(false,
                                             "",
                                              "No such employee exists");
            }  

            try
            {
                _employeeRepository.RemoveAsync(deleteEmployee);
            }
            catch (Exception)
            {
                return new CreateEmployeeRequestModel(false,
                                              "",
                                              "Could not delete employee..");
            }

            return new CreateEmployeeRequestModel(true,
                                          "CMS-02",
                                          "The Employee   was successfully deleted");
        }
        public async Task<List<EmployeeDto>> LoadAllEmployee()
        {
            return await _employeeRepository.GetEmployeeDtos();
        }

        public async Task<EmployeeDto> LoadEmployeeDetail(Guid id)
        {
            return await _employeeRepository.LoadEmployeeDetailAsync(id);
        }


        public async Task<UpdateEmployeeRequestModel> Update(Guid id, EmployeeDto request)
        {
            DateTime modified = DateTime.Now;
            try
            {
                var std = _employeeRepository.GetById(id);

                if (std != null)
                {
                    std.Surname = request.Surname;
                    std.Firstname = request.Firstname;
                    std.Lastname = request.Lastname;
                    std.Gender = request.Gender;
                    std.IsActive = request.IsActive;
                    std.DepartmentId = request.DepartmentId;
                    _employeeRepository.UpdateAsync(std);
                }
                else
                {
                    return new UpdateEmployeeRequestModel(false,
                                                 "",
                                                 "No such student exist");
                }
            }
            catch (Exception ex)
            {
                return new UpdateEmployeeRequestModel(false,
                                                 "",
                                                 "Something went wrong");
            }
            return new UpdateEmployeeRequestModel(true,
                                                 "",
                                                 "Student Successfully Updated");

        }

        
    }
}




