using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly ICategoryRepository _repository;

        public GetAllCategoriesService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _repository.GetAllAsync();
        }
    }
}