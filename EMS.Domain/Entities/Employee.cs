using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = false;
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; } 
        public string Password { get; set; }
        public string Role { get; set; } 
        public string Email { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
