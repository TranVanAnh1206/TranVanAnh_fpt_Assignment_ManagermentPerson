using AutoMapper;
using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.Models;
using ManagementPerson.Api.ViewModels;
using TranVanAnh_QuizzApp.Infrastructure.Services;

namespace ManagementPerson.Api.Services
{
    public class StudentService : BaseService<StudentViewModel, Student, StudentCreateUpdateViewModel>, IStudentService
    {
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper) : base(studentRepository)
        {
            _mapper = mapper;
        }

        protected override StudentViewModel ConvertToDto(Student entity)
        {
            return _mapper.Map<StudentViewModel>(entity);
        }

        protected override Student ConvertToEntity(StudentViewModel dto)
        {
            return _mapper.Map<Student>(dto);
        }

        protected override Student ConvertToEntity(StudentCreateUpdateViewModel dto)
        {
            return _mapper.Map<Student>(dto);
        }
    }
}
