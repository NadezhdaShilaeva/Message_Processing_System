namespace Presentation.Models.Messages
{
    public record CreatePhoneMessageModel(Guid phoneSourceId, string text);
}
