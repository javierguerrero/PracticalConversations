using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IGetQuestionService
    {
        Question GetQuestion(int questionId);
    }
}