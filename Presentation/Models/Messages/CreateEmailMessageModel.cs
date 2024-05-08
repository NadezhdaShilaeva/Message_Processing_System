namespace Presentation.Models.Messages
{
    public record CreateEmailMessageModel(Guid emailSourceId, string text);
}
