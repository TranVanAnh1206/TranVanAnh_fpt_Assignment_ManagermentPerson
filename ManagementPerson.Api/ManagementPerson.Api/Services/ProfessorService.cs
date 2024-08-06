using AutoMapper;
using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.Models;
using ManagementPerson.Api.ViewModels;
using TranVanAnh_QuizzApp.Infrastructure.Services;

namespace ManagementPerson.Api.Services
{
    public class ProfessorService : BaseService<ProfessorViewModel, Professor, ProfessorCreateUpdateViewModel>, IProfessorService
    {
        private readonly IMapper _mapper;

        public ProfessorService(IProfessorRepository professorRepository, IMapper mapper) : base(professorRepository)
        {
            _mapper = mapper;
        }

        protected override ProfessorViewModel ConvertToDto(Professor entity)
        {
            return _mapper.Map<ProfessorViewModel>(entity);
        }

        protected override Professor ConvertToEntity(ProfessorViewModel dto)
        {
            return _mapper.Map<Professor>(dto);
        }

        protected override Professor ConvertToEntity(ProfessorCreateUpdateViewModel dto)
        {
            return _mapper.Map<Professor>(dto);
        }
    }
}
