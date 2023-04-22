using Domain.Interfaces.AI;
using Domain.Interfaces.Repositories;
using Infrastructure.AI;
using Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyección de depndencias de servicios personalizados
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IChatbot, ChatGPT>();
            services.AddScoped<IGenerativeAI, GenerativeAI>();

            return services;
        }
    }
}