using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.AI
{
    public interface IGenerativeAI
    {
        Task<Conversation> GenerateConversation(string prompt);
    }
}
