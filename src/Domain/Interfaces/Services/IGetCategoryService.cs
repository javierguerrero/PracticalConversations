using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IGetCategoryService
    {
        Category GetCategory(int categoryId);
    }
}