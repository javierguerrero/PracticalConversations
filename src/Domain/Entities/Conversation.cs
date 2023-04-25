namespace Domain.Entities
{
    public class Conversation
    {
        public string RawData { get; set; }

        public List<string> Participants { get; set; }

        public ICollection<Turn> Turns { get; set; }

        public Conversation()
        {
            Turns = new List<Turn>();
        }
    }
}