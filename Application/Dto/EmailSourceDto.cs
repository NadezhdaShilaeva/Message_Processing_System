namespace Application.Dto
{
    public record EmailSourceDto(Guid id, IReadOnlyCollection<EmailMessageDto> messages);
}
