using Application.Services;
using AutoMapper;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración AutoMapper
            var autoMapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddMaps(typeof(IMapperService).Assembly);
            });
            IMapper mapper = autoMapperConfig.CreateMapper();

            // Inyección de dependencias de servicios personalizados
            services.AddSingleton(mapper);
            services.AddScoped<IMapperService, MapperService>();
            services.AddScoped<IGetAllCategoriesService, GetAllCategoriesService>();
            services.AddScoped<IGetQuestionsService, GetQuestionsService>();
            services.AddScoped<IGetQuestionService, GetQuestionService>();
            services.AddScoped<IGetCategoryService, GetCategoryService>();
            services.AddScoped<IGenerateConversationService, GenerateConversationService>();

            return services;
        }
    }
}