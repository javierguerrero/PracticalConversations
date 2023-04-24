using Domain.Entities;
using Domain.Interfaces.AI;

namespace Infrastructure.AI
{
    public class GenerativeAI : IGenerativeAI
    {
        public readonly IChatbot _chatbot;

        public GenerativeAI(IChatbot chatbot)
        {
            this._chatbot = chatbot;
        }

        public async Task<Conversation> GenerateConversation(string prompt)
        {
            var rawData = await _chatbot.GenerateResponse(prompt);

            string[] lines = rawData.Split(new string[] { "\n", "\\n" }, StringSplitOptions.None);
            List<string> list = new List<string>(lines);
            var filteredList = list.Where(s => s != "").ToList();

            var conversation = new Conversation();
            conversation.RawData = rawData;

            return conversation;
        }
    }
}