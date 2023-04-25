namespace Application.DTOs
{
    public class ConversationDto
    {
        public string RawData { get; set; }

        public List<string> Participants { get; set; }

        public ICollection<TurnDto> Turns { get; set; }

        public ConversationDto()
        {
            Turns = new List<TurnDto>();
        }
    }
}