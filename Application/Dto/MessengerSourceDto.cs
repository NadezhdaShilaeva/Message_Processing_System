namespace Application.Dto
{
    public record MessengerSourceDto(Guid id, IReadOnlyCollection<MessengerMessageDto> messages);
}