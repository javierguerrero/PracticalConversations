using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class GetQuestionsService : IGetQuestionsService
    {
        private readonly IQuestionRepository _repository;

        public GetQuestionsService(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Question>> GetQuestions(int categoryId)
        {
            return await _repository.GetQuestionAsync(categoryId);
        }
    }
}