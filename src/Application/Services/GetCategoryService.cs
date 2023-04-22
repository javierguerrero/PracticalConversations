using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class GetCategoryService : IGetCategoryService
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Category GetCategory(int categoryId)
        {
            return _repository.GetCategoyById(categoryId);
        }

    }
}