using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class GetQuestionService : IGetQuestionService
    {
        private readonly IQuestionRepository _repository;

        public GetQuestionService(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public Question GetQuestion(int questionId)
        {
            return _repository.GetQuestionById(questionId);
        }

    }
}