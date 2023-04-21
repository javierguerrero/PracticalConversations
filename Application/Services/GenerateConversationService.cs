using Domain.Entities;
using Domain.Interfaces.AI;
using Domain.Interfaces.Services;

namespace Application.Services
{
    public class GenerateConversationService : IGenerateConversationService
    {
        private readonly IGenerativeAI _generativeAI;

        public GenerateConversationService(IGenerativeAI generativeAI)
        {
            _generativeAI = generativeAI;
        }

        public async Task<Conversation> GenerateConversation(string prompt)
        {
            return await _generativeAI.GenerateConversation(prompt);
        }
    }
}