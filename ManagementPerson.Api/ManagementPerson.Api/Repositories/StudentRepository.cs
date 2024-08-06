using ManagementPerson.Api.Data;
using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.Models;

namespace ManagementPerson.Api.Repositories
{
    public class StudentRepository : BaseRepostory<Student>, IStudentRepository
    {
        public StudentRepository(ManagerPersionDbContext dbContext) : base(dbContext)
        {
        }
    }
}
