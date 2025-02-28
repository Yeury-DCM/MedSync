
using AutoMapper;
using MedSync.Core.Application.Interfaces.Repositories;
using MedSync.Core.Application.Interfaces.Services;
using MedSync.Core.Application.Interfaces.ViewModels;
using MedSync.Core.Domain.Common;

namespace MedSync.Core.Application.Services
{
    public class GenericService<ViewModel, SaveViewModel, Entity> : IGenericService<ViewModel, SaveViewModel, Entity>
        where ViewModel : class
        where SaveViewModel : class, IHaveId
        where Entity : class, IAuditableEntity
        
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel saveViewModel)
        {
            Entity entity = _mapper.Map<Entity>(saveViewModel);
            entity.CreatedOn = DateTime.Now;
            entity.CreatedBy = 0;
        
           
    
            return  _mapper.Map<SaveViewModel>(await _repository.AddAsync(entity)) ;
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

        public virtual async Task<SaveViewModel?> GetByIdSaveViewModel(int id)
        {
            Entity? entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<SaveViewModel>(entity);
        }

        public virtual async Task<bool> Update(SaveViewModel viewModel)
        {
            Entity entity = await _repository.GetByIdAsync(viewModel.Id);
            entity = _mapper.Map(viewModel, entity);
            return await _repository.UpdateAsync(entity);
        }
    }
}
