using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IGetQuestionsService
    {
        Task<IEnumerable<Question>> GetQuestions(int categoryId);
    }
}