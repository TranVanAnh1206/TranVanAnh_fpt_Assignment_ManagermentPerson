using ManagementPerson.Api.Data;
using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.Models;

namespace ManagementPerson.Api.Repositories
{
    public class AddressRepository : BaseRepostory<Address>, IAddressRepository
    {
        public AddressRepository(ManagerPersionDbContext dbContext) : base(dbContext)
        {
        }
    }
}
