namespace Presentation.Models.Messages
{
    public record CreateMessengerMessageModel(Guid messengerSourceId, string text);
}
