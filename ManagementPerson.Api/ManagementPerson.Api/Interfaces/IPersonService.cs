using ManagementPerson.Api.ViewModels;

namespace ManagementPerson.Api.Interfaces
{
    public interface IPersonService : IBaseService<PersonViewModel, PersonCreateViewModel>
    {
    }
}
