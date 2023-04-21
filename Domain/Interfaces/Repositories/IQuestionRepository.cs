using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestionAsync(int categoryId);
    }
}