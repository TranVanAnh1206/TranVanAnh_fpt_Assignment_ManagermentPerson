using ManagementPerson.Api.Extensions;

namespace ManagementPerson.Api.Interfaces
{
    public interface IBaseService <TDto, TCreateUpdate> where TDto : class where TCreateUpdate : class
    {
        Task<int> CreateAsync(TCreateUpdate dtoCreate);
        Task<int> UpdateAsync(TCreateUpdate dtoEdit);
        Task<int> DeleteAsync(int id);
        Task<PaginationList<TDto>> GetAllAsync(BaseSpecification spec, PaginationParams pageParams, string[] includes = null);
        Task<TDto> GetById(int id, string[] includes = null);
    }
}
