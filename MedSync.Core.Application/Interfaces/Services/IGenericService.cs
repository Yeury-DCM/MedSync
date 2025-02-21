namespace MedSync.Core.Application.Interfaces.Services
{
    public interface IGenericService <ViewModel, SaveViewModel, Entity>
    {
        Task<List<ViewModel>> GetAllViewModel();
        Task<ViewModel?> GetById(int id);
        Task<SaveViewModel> GetByIdSaveViewModel(int id);
        Task<SaveViewModel> Add(SaveViewModel saveViewModel);
        Task<bool> Update(SaveViewModel viewModel);
        Task<bool> Delete(int id);
    }
}
