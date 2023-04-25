namespace Application.DTOs
{
    public class ConversationDto
    {
        public ICollection<TurnDto> Turns { get; set; }

        public ConversationDto()
        {
            Turns = new List<TurnDto>();
        }
    }
}