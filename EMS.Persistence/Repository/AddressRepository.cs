using EMS.Application.Interface.Repository;
using EMS.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistence.Repository
{
    public class AddressRepository : RepositoryAsync, IAddressRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AddressRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
