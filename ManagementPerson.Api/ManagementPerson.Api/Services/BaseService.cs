using ManagementPerson.Api.Extensions;
using ManagementPerson.Api.Interfaces;

namespace TranVanAnh_QuizzApp.Infrastructure.Services
{
    public class BaseService<TDto, TEntity, TCreateUpdate> 
        : IBaseService<TDto, TCreateUpdate> where TEntity : class where TDto : class where TCreateUpdate : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        protected virtual TEntity ConvertToEntity (TDto dto) => throw new NotImplementedException();
        protected virtual TEntity ConvertToEntity (TCreateUpdate dto) => throw new NotImplementedException();
        protected virtual TDto ConvertToDto (TEntity entity) => throw new NotImplementedException();

        public virtual async Task<int> CreateAsync(TCreateUpdate dtoCreate)
        {
            var entity = ConvertToEntity(dtoCreate);
            await _baseRepository.CreateAsync(entity);
            return 1;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync(id);
        }

        public virtual async Task<PaginationList<TDto>> GetAllAsync(BaseSpecification spec, PaginationParams pageParams, string[] includes = null)
        {
            var entities = await _baseRepository.GetAllAsync(includes);
            var dtos = entities.Select(x => ConvertToDto(x));
            var pagingList = PaginationList<TDto>.Create(dtos, pageParams.PageNumber, pageParams.PageSize);
            return pagingList;
        }

        public async Task<TDto> GetById(int id, string[] includes = null)
        {
            var dto = await _baseRepository.GetById(id, includes);
            return ConvertToDto(dto);
        }

        public async Task<int> UpdateAsync(TCreateUpdate dtoEdit)
        {
            var entity = ConvertToEntity(dtoEdit);
            return await _baseRepository.UpdateAsync(entity);
        }
    }
}
