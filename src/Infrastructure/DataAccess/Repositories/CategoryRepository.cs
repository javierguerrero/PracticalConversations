using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infrastructure.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryRepository()
        {
            _categories = new List<Category>() {
                    new Category() { Id = 1, Name = "Age and Aging"},
                    new Category() { Id = 2, Name = "Animals"},
                    new Category() { Id = 3, Name = "Appearance"},
                    new Category() { Id = 4, Name = "Around the Neighborhood"},
                    new Category() { Id = 5, Name = "Art"},
                    new Category() { Id = 6, Name = "Birthdays"},
                    new Category() { Id = 7, Name = "Books"},
                    new Category() { Id = 8, Name = "Business"},
                    new Category() { Id = 9, Name = "Cars and Driving"},
                    new Category() { Id = 10, Name = "Childhood"},
                    new Category() { Id = 11, Name = "Chores"},
                    new Category() { Id = 12, Name = "Clothes and Fashion"},
                    new Category() { Id = 13, Name = "Communication"},
                    new Category() { Id = 14, Name = "Community "},
                    new Category() { Id = 15, Name = "Controversial Things"},
                    new Category() { Id = 16, Name = "Cooking at Home"},
                    new Category() { Id = 17, Name = "Christmas"},
                    new Category() { Id = 18, Name = "Countries"},
                    new Category() { Id = 19, Name = "Current Events"},
                    new Category() { Id = 20, Name = "Dating and Marriage"},
                    new Category() { Id = 21, Name = "Drinking"},
                    new Category() { Id = 22, Name = "Eating Out"},
                    new Category() { Id = 23, Name = "The Environment"},
                    new Category() { Id = 24, Name = "Exercise"},
                    new Category() { Id = 25, Name = "Family"},
                    new Category() { Id = 26, Name = "Food"},
                    new Category() { Id = 27, Name = "Free Time"},
                    new Category() { Id = 28, Name = "Friends"},
                    new Category() { Id = 29, Name = "Future"},
                    new Category() { Id = 30, Name = "Gender Roles"},
                    new Category() { Id = 31, Name = "Getting a Job"},
                    new Category() { Id = 32, Name = "Getting to Know Someone"},
                    new Category() { Id = 33, Name = "Going to a Party "},
                    new Category() { Id = 34, Name = "Habits"},
                    new Category() { Id = 35, Name = "Happiness"},
                    new Category() { Id = 36, Name = "Hobbies"},
                    new Category() { Id = 37, Name = "Holidays"},
                    new Category() { Id = 38, Name = "Home"},
                    new Category() { Id = 39, Name = "The Internet"},
                    new Category() { Id = 40, Name = "Jobs"},
                    new Category() { Id = 41, Name = "Laws"},
                    new Category() { Id = 42, Name = "Learning English "},
                    new Category() { Id = 43, Name = "Manners"},
                    new Category() { Id = 44, Name = "Meeting People"},
                    new Category() { Id = 45, Name = "Money"},
                    new Category() { Id = 46, Name = "Movies"},
                    new Category() { Id = 47, Name = "Music"},
                    new Category() { Id = 48, Name = "Mysterious Things"},
                    new Category() { Id = 49, Name = "Pets"},
                    new Category() { Id = 50, Name = "Plans for the Future"},
                    new Category() { Id = 51, Name = "Political Things"},
                    new Category() { Id = 52, Name = "Possessions"},
                    new Category() { Id = 53, Name = "Retirement"},
                    new Category() { Id = 54, Name = "School Days"},
                    new Category() { Id = 55, Name = "Seasons"},
                    new Category() { Id = 56, Name = "Shopping"},
                    new Category() { Id = 57, Name = "Sleep"},
                    new Category() { Id = 58, Name = "Smoking"},
                    new Category() { Id = 59, Name = "Social Problems"},
                    new Category() { Id = 60, Name = "Sports"},
                    new Category() { Id = 61, Name = "Stress"},
                    new Category() { Id = 62, Name = "Technology"},
                    new Category() { Id = 63, Name = "Things that Annoy You"},
                    new Category() { Id = 64, Name = "Time"},
                    new Category() { Id = 65, Name = "Travel"},
                    new Category() { Id = 66, Name = "TV"},
                    new Category() { Id = 67, Name = "Weather"},

            };
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return _categories;
        }

        public Category GetCategoyById(int id)
        {
            return _categories.Single(q => q.Id == id);
        }
    }
}