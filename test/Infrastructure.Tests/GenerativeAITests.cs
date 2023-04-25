using Infrastructure.AI;
using Moq;
using Xunit;

namespace Infrastructure.Tests
{
    public class GenerativeAITests
    {
        [Fact]
        public async void GenerateConversation_CreatesConversationWithExpectedParticipants()
        {
            //Arrange
            var participant1 = "Person 1";
            var participant2 = "Person 2";
            var expectedParticipants = new List<string> { participant1, participant2 };

            var mock = new Mock<IChatbot>(MockBehavior.Strict);
            mock.Setup(chatbot => chatbot.GenerateResponse(string.Empty)).ReturnsAsync("Person 1: Hey, have you ever been afraid of any animals?\n\nPerson 2: Well, I can't say I'm a huge fan of spiders.\n\nPerson 1: Oh really? I don't think they're that scary. What about snakes?\n\nPerson 2: I don't particularly like them, but I wouldn't say I'm afraid of them.\n\nPerson 1: What about sharks? They seem to be a popular fear.\n\nPerson 2: Definitely! I've never been in a situation where I've had to deal with one though.\n\nPerson 1: Yeah, I can understand why they're scary. How about something more common like dogs?\n\nPerson 2: I'm actually a big dog lover, so no, not afraid of them.\n\nPerson 1: That's good to know. Any other animals that make you uneasy?\n\nPerson 2: Hmm, not really. I tend to be pretty calm around most animals.\n\nPerson 1: I see. I'm a bit afraid of heights myself, so I can understand how certain things can create a sense of unease.\n\nPerson 2: Yeah, everyone has their own fears, no matter how small or silly they may seem. It's all about how you deal with them.");
            var generativeAI = new GenerativeAI(mock.Object);

            //Act
            var conversation = await generativeAI.GenerateConversation(string.Empty);

            //Assert
            Assert.Equal(expectedParticipants, conversation.Participants);
        }

        [Fact]
        public async void GenerateConversation_ConversationHasAtLeastTwoTurns()
        {
            //Arrange
            var mock = new Mock<IChatbot>(MockBehavior.Strict);
            mock.Setup(chatbot => chatbot.GenerateResponse(string.Empty)).ReturnsAsync("Person 1: Hey, have you ever been afraid of any animals?\n\nPerson 2: Well, I can't say I'm a huge fan of spiders.\n\nPerson 1: Oh really? I don't think they're that scary. What about snakes?\n\nPerson 2: I don't particularly like them, but I wouldn't say I'm afraid of them.\n\nPerson 1: What about sharks? They seem to be a popular fear.\n\nPerson 2: Definitely! I've never been in a situation where I've had to deal with one though.\n\nPerson 1: Yeah, I can understand why they're scary. How about something more common like dogs?\n\nPerson 2: I'm actually a big dog lover, so no, not afraid of them.\n\nPerson 1: That's good to know. Any other animals that make you uneasy?\n\nPerson 2: Hmm, not really. I tend to be pretty calm around most animals.\n\nPerson 1: I see. I'm a bit afraid of heights myself, so I can understand how certain things can create a sense of unease.\n\nPerson 2: Yeah, everyone has their own fears, no matter how small or silly they may seem. It's all about how you deal with them.");
            var generativeAI = new GenerativeAI(mock.Object);

            //Act
            var conversation = await generativeAI.GenerateConversation(string.Empty);

            //Assert
            Assert.True(conversation.Turns.Count >= 2);
        }
    }
}