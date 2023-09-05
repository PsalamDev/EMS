using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.DTOs.Address
{
    public class AddressDto
    { 
      public int PhoneNumber { get; set; }
      public string address { get; set; }
      public Guid EmployeedId { get; set; }

    }
}


