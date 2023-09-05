 namespace EMS.Application.DTOs.Employee
{
    public class EmployeeDto
    {    
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = false;
       
    }
}
