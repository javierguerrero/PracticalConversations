using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestionsAsync(int categoryId);
        Question GetQuestionById(int id);
    }
}