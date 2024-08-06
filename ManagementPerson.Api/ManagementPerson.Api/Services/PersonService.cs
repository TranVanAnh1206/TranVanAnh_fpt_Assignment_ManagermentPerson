using AutoMapper;
using ManagementPerson.Api.Extensions;
using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.Models;
using ManagementPerson.Api.Repositories;
using ManagementPerson.Api.ViewModels;
using TranVanAnh_QuizzApp.Infrastructure.Services;

namespace ManagementPerson.Api.Services
{
    public class PersonService : BaseService<PersonViewModel, Person, PersonCreateViewModel>, IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper) : base(personRepository)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        protected override PersonViewModel ConvertToDto(Person entity)
        {
            return _mapper.Map<PersonViewModel>(entity);
        }

        protected override Person ConvertToEntity(PersonViewModel dto)
        {
            return _mapper.Map<Person>(dto);
        }

        protected override Person ConvertToEntity(PersonCreateViewModel dto)
        {
            return _mapper.Map<Person>(dto);
        }

        public override async Task<PaginationList<PersonViewModel>> GetAllAsync(BaseSpecification spec, PaginationParams pageParams, string[] includes = null)
        {
            var entities = await _personRepository.GetAllAsync(includes);

            if (spec != null && !string.IsNullOrEmpty(spec.Filter))
            {
                entities = entities.Where(x => x.Name.Contains(spec.Filter) || x.PhoneNumber.Contains(spec.Filter) || x.EmailAddress.Contains(spec.Filter));
            }

            var dtos = entities.Select(x => ConvertToDto(x));
            var pagingList = PaginationList<PersonViewModel>.Create(dtos, pageParams.PageNumber, pageParams.PageSize);
            return pagingList;
        }
    }
}
