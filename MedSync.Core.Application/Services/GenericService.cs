
using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Domain.Common;

namespace MedSync.Core.Application.Services
{
    public class GenericService<ViewModel, SaveViewModel, Entity> : IGenericService<ViewModel, SaveViewModel, Entity>
        where ViewModel : class
        where SaveViewModel : class
        where Entity : class, IAuditableEntity
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<Entity> Add(SaveViewModel saveViewModel)
        {
            Entity entity = _mapper.Map<Entity>(saveViewModel);
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = 0;
    
            return await _repository.AddAsync(entity);
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
           List<Entity> entities = (List<Entity>) await _repository.GetAllAsync();

           return _mapper.Map<List<ViewModel>> (entities);
        }

        public virtual async Task<ViewModel?> GetById(int id)
        {
            Entity? entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ViewModel>(entity);
        }

        public async Task<bool> Update(SaveViewModel viewModel)
        {
            Entity entity = _mapper.Map<Entity>(viewModel);
            return await _repository.UpdateAsync(entity);
        }
    }
}
