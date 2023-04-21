using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infrastructure.DataAccess.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private List<Question> _questions;

        public QuestionRepository()
        {
            _questions = new List<Question>() {
                new Question() { Id = 1, Text = "filosfia", CategoryId = 1 },
                new Question() { Id = 2, Text = "historia", CategoryId = 1 },
                new Question() { Id = 3, Text = "música", CategoryId = 2 },
                new Question() { Id = 4, Text = "teatro", CategoryId = 2 },
            };
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync(int categoryId)
        {
            return _questions
                .Where(q => q.CategoryId == categoryId)
                .ToList();
        }

        public  Question GetQuestionById(int id)
        {
            return _questions.Single(q => q.Id == id);
        }
    }
}