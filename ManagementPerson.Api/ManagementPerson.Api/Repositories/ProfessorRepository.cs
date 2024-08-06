using ManagementPerson.Api.Data;
using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.Models;

namespace ManagementPerson.Api.Repositories
{
    public class ProfessorRepository : BaseRepostory<Professor>, IProfessorRepository
    {
        public ProfessorRepository(ManagerPersionDbContext dbContext) : base(dbContext)
        {
        }
    }
}
