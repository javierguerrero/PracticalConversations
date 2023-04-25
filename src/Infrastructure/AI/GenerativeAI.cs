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

            string[] rawDataLines = rawData.Split(new string[] { "\n", "\\n" }, StringSplitOptions.None);
            List<string> lines = new List<string>(rawDataLines);
            lines = lines.Where(s => s != string.Empty).ToList();

            var participants = new List<string>();
            var turns = new List<Turn>();
            var count = 0;

            foreach (var line in lines)
            {
                var participant = line.Substring(0, line.IndexOf(':'));
                var message = line.Substring(line.IndexOf(":") + 2);

                participants.Add(participant);

                turns.Add(new Turn()
                {
                    Order = ++count,
                    Speaker = participant,
                    Message = message
                });
            }

            var conversation = new Conversation()
            {
                RawData = rawData,
                Participants = participants.Distinct().ToList(),
                Turns = turns
            };

            return conversation;
        }
    }
}