using ManagementPerson.Api.Data;
using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.Models;

namespace ManagementPerson.Api.Repositories
{
    public class PersonRepository : BaseRepostory<Person>, IPersonRepository
    {
        public PersonRepository(ManagerPersionDbContext dbContext) : base(dbContext)
        {
        }
    }
}
