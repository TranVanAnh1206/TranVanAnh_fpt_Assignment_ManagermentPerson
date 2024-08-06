using AutoMapper;
using ManagementPerson.Api.Models;
using ManagementPerson.Api.ViewModels;

namespace TranVanAnh_QuizzApp.Infrastructure.ObjectMapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PersonViewModel, Person>();
            CreateMap<PersonCreateViewModel, Person>();

            CreateMap<Person, PersonViewModel>()
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src is Student ? src as Student : null))
                .ForMember(dest => dest.Professor, opt => opt.MapFrom(src => src is Professor ? src as Professor : null))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

            CreateMap<Address, AddressViewModel>();
            CreateMap<AddressViewModel, Address>();
            CreateMap<AddressCreateUpdateViewModel, Address>();

            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();
            CreateMap<StudentCreateUpdateViewModel, Student>()
                .ForMember(x => x.Name, x => x.MapFrom(e => e.Name))
                .ForMember(x => x.AddressId, x => x.MapFrom(e => e.AddressId))
                .ForMember(x => x.PhoneNumber, x => x.MapFrom(e => e.PhoneNumber))
                .ForMember(x => x.EmailAddress, x => x.MapFrom(e => e.EmailAddress));

            CreateMap<Professor, ProfessorViewModel>();
            CreateMap<ProfessorViewModel, Professor>();
            CreateMap<ProfessorCreateUpdateViewModel, Professor>()
                .ForMember(x => x.Name, x => x.MapFrom(e => e.Name))
                .ForMember(x => x.AddressId, x => x.MapFrom(e => e.AddressId))
                .ForMember(x => x.PhoneNumber, x => x.MapFrom(e => e.PhoneNumber))
                .ForMember(x => x.EmailAddress, x => x.MapFrom(e => e.EmailAddress));
        }
    }
}
