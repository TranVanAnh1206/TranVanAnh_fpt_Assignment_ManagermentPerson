using AutoMapper;
using ManagementPerson.Api.Interfaces;
using ManagementPerson.Api.Models;
using ManagementPerson.Api.ViewModels;
using TranVanAnh_QuizzApp.Infrastructure.Services;

namespace ManagementPerson.Api.Services
{
    public class AddressService : BaseService<AddressViewModel, Address, AddressCreateUpdateViewModel>, IAddressService
    {
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper) : base(addressRepository)
        {
            _mapper = mapper;
        }

        protected override AddressViewModel ConvertToDto(Address entity)
        {
            return _mapper.Map<AddressViewModel>(entity);
        }

        protected override Address ConvertToEntity(AddressViewModel dto)
        {
            return _mapper.Map<Address>(dto);
        }

        protected override Address ConvertToEntity(AddressCreateUpdateViewModel dto)
        {
            return _mapper.Map<Address>(dto);
        }
    }
}
