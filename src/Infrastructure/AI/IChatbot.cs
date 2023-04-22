namespace Infrastructure.AI
{
    public interface IChatbot
    {
        Task<string> GenerateResponse(string prompt);
    }
}