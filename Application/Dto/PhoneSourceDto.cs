namespace Application.Dto
{
    public record PhoneSourceDto(Guid id, IReadOnlyCollection<PhoneMessageDto> messages);
}