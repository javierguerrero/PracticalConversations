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
                new Question() { Id = 1, CategoryId = 1, Text = "What is the best age to be? Why?" },
                new Question() { Id = 2, CategoryId = 1, Text = "What's been your favorite age so far in your life? Why?" },
                new Question() { Id = 3, CategoryId = 1, Text = "Do you have any fears about getting older? What are they?" },
                new Question() { Id = 4, CategoryId = 1, Text = "Who is the oldest person that you know? Are you close to him/her?" },
                new Question() { Id = 5, CategoryId = 1, Text = "Is age important in your culture?" },
                new Question() { Id = 6, CategoryId = 1, Text = "Can people of different ages be friends?" },
                new Question() { Id = 7, CategoryId = 1, Text = "Are you friends with someone much older or younger than you?" },
                new Question() { Id = 8, CategoryId = 1, Text = "What are some of your earliest memories?" },
                new Question() { Id = 9, CategoryId = 1, Text = "What was the hardest part about growing up for you?" },
                new Question() { Id = 10, CategoryId = 1, Text = "What advice would you give to your younger self?" },
                new Question() { Id = 11, CategoryId = 1, Text = "What do you think of nursing homes? Are they a nice option for older people or should they live with family members?" },
                new Question() { Id = 12, CategoryId = 1, Text = "What is a good age to 'settle down' and get married?" },
                new Question() { Id = 13, CategoryId = 1, Text = "Should younger people respect the elderly? Why or why not?" },
                new Question() { Id = 14, CategoryId = 1, Text = "Where you're from, is it okay to ask people about their age?" },
                new Question() { Id = 15, CategoryId = 1, Text = "Should job applicants be required to disclose their age to potential employers?" }
            };
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync(int categoryId)
        {
            return _questions
                .Where(q => q.CategoryId == categoryId)
                .ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _questions.Single(q => q.Id == id);
        }
    }
}