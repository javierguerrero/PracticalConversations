using Application.DTOs;

namespace WebUI.ViewModels
{
    public class ConversationViewModel
    {
        public string Category { get; set; }
        public string Question { get; set; }
        public ConversationDto Conversation { get; set; }
    }
}